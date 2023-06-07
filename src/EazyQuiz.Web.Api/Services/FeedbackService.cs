using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Сервис работающий с обратной связью
/// </summary>
public class FeedbackService
{
    /// <inheritdoc cref="DataContext" />
    private readonly DataContext _dataContext;

    /// <inheritdoc cref="IMapper" />
    private readonly IMapper _mapper;

    public FeedbackService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    /// <summary>
    ///     Добавить новую обратную связь
    /// </summary>
    /// <param name="feedback">Запрос на добавление</param>
    /// <param name="token">Токен отмены запроса</param>
    public async Task AddNewFeedback(FeedbackRequest feedback, CancellationToken token)
    {
        var feedbackEntity = _mapper.Map<Feedback>(feedback);
        _dataContext.Add(feedbackEntity);
        await _dataContext.SaveChangesAsync(token);
    }

    /// <summary>
    ///     Получить коллекцию обратной связи
    /// </summary>
    /// <param name="status">Статус</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция обратной связи</returns>
    public async Task<IReadOnlyCollection<FeedbackResponse>> GetFeedback(string status, CancellationToken token)
    {
        var feedbacks = await _dataContext.Set<Feedback>()
            .AsNoTracking()
            .Where(x => x.Status == status)
            .ToListAsync(token);
        return feedbacks.Select(_mapper.Map<FeedbackResponse>).ToList();
    }

    /// <summary>
    ///     Обновить статус обратной связи
    /// </summary>
    /// <param name="feedbackUpdate">Команда</param>
    /// <param name="token">Токен отмены запроса</param>
    public async Task UpdateFeedbacks(FeedbackUpdateDTO feedbackUpdate, CancellationToken token)
    {
        var feedback = await _dataContext.Set<Feedback>()
            .Where(x => x.Id == feedbackUpdate.Id)
            .SingleAsync(token);

        feedback.Status = feedbackUpdate.Status;

        _dataContext.Update(feedback);

        await _dataContext.SaveChangesAsync(token);
    }
}
