using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;
/// <summary>
/// Контроллер работы с вопросами
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController, Authorize]
public class QuestionsController : Controller
{
    /// <summary>
    /// <inheritdoc cref="QuestionsService"/>
    /// </summary>
    private readonly QuestionsService _questionsService;
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(QuestionsService questionsService, ILogger<QuestionsController> logger)
    {
        _questionsService = questionsService;
        _logger = logger;
    }

    /// <summary>
    /// Получить вопрос с ответом
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionWithAnswers))]
    public async Task<IActionResult> GetQuestion()
    {
        _logger.LogInformation("GetQuestion");
        return Ok(await _questionsService.GetQuestion());
    }

    [HttpPost]
    public async Task<IActionResult> PostUserAnswer([FromBody] UserAnswer answer)
    {
        await _questionsService.WriteUserAnswer(answer);
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Add([FromBody] QuestionWithoutId question)
    {
        await _questionsService.AddQuestion(question);
        return Ok();
    }
}
