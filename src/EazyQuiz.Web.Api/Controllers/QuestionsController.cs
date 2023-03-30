using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Получить коллекцию из 10ти вопросов 
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<QuestionWithAnswers>))]
    public async Task<IActionResult> GetQuestions()
    {
        _logger.LogInformation("Get 10 Question");
        return Ok(await _questionsService.GetTenQuestions());
    }

    /// <summary>
    /// Записать ответ пользователя в бд
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> PostUserAnswer([FromBody] UserAnswer answer)
    {
        await _questionsService.WriteUserAnswer(answer);
        return Ok();
    }

    /// <summary>
    /// Добавить вопрос с админки
    /// </summary>
    [HttpPost(nameof(Add))]
    [AllowAnonymous]
    public async Task<IActionResult> Add([FromBody] QuestionWithoutId question)
    {
        await _questionsService.AddQuestion(question);
        return Ok();
    }
}
