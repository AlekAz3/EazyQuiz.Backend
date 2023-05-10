using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контроллер работы с вопросами
/// </summary>
public class QuestionsController : BaseController
{
    /// <inheritdoc cref="QuestionsService"/>
    private readonly QuestionsService _questionsService;

    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(QuestionsService questionsService, ILogger<QuestionsController> logger)
    {
        _questionsService = questionsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestionByFilter([FromQuery] GetQuestionCommand command, CancellationToken token)
    {
        var questions = await _questionsService.GetQuestionsByFilter(command, token);
        return Ok(questions);
    }

    /// <summary>
    /// Записать ответ пользователя в бд
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> PostUserAnswer([FromBody] UserAnswer answer)
    {
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        await _questionsService.WriteUserAnswer(userId, answer);
        return Ok();
    }

    /// <summary>
    /// Добавить вопрос с админки
    /// </summary>
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] QuestionWithoutId question)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _questionsService.AddQuestion(question);
        return Ok();
    }
}
