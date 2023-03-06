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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<QuestionWithAnswers>))]
    public async Task<IActionResult> GetQuestions()
    {
        _logger.LogInformation("Get 10 Question");
        return Ok(await _questionsService.GetTenQuestions());
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
