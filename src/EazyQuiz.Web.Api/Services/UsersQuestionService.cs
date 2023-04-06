using AutoMapper;
using EazyQuiz.Extensions;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api.Services;

/// <summary>
/// Сервис по работе с предложенными вопросами от пользователей 
/// </summary>
public class UsersQuestionService
{
    /// <inheritdoc cref="DataContext"/>
    private readonly DataContext _context;

    /// <inheritdoc cref="IMapper"/>
    private readonly IMapper _mapper;

    public UsersQuestionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddNewUserQuestionToQueue(AddQuestionByUser questionByUser, CancellationToken token)
    {
        var question = _mapper.Map<UsersQuesions>(questionByUser);
        await _context.UsersQuestions.AddAsync(question, token);
        await _context.SaveChangesAsync(token);
    }

    public async Task<InputCountDTO<QuestionByUserResponse>> GetUsersQuestions(Guid userId, GetHistoryCommand command, CancellationToken token)
    {
        int totalCount = await _context.UsersQuestions
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .CountAsync(token);

        var usersQuestions = await _context.UsersQuestions
            .AsNoTracking()
            .OrderByDescending(x => x.LastUpdate)
            .Where(x => x.UserId == userId)
            .AddPagination(command)
            .ToListAsync(token);

        var result = usersQuestions.Select(x => _mapper.Map<QuestionByUserResponse>(x));

        return new InputCountDTO<QuestionByUserResponse>(totalCount, result);
    }

    public async Task<IReadOnlyCollection<UserQuestionResponse>> GetByFilter(UserQuestionFilter filter, CancellationToken token)
    {
        var data = await _context.UsersQuestions
            .AsNoTracking()
            .Where(x => filter.Status.IsNullOrEmpty() || x.Status == filter.Status)
            .AddPagination(filter)
            .ToListAsync(token);

        var kek = data.Select(x => _mapper.Map<UserQuestionResponse>(x)).ToList();
        return kek;
    }
    public async Task UpdateUserQuestion(UpdateUserQuestion question, CancellationToken token)
    {
        var data = await _context.UsersQuestions
            .Where(x => x.Id == question.Id).SingleOrDefaultAsync(token);

        if (!question.Status.IsNullOrEmpty())
        {
            data.Status = question.Status;
        }

        if (!question.QuestionText.IsNullOrEmpty())
        {
            data.QuestionText = question.QuestionText;
        }

        if (!question.AnswerText.IsNullOrEmpty())
        {
            data.AnswerText = question.AnswerText;
        }

        await _context.SaveChangesAsync(token);
    }
}
