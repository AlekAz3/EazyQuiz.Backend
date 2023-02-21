using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    private readonly IQuestionsService _questionsService;

    /// <summary>
    /// <inheritdoc cref="ILogger{TCategoryName}"/>
    /// </summary>
    private readonly ILogger<QuestionsController> _log;

    public QuestionsController(IQuestionsService questionsService, ILogger<QuestionsController> logger)
    {
        _questionsService = questionsService;
        _log = logger;
    }

    /// <summary>
    /// Получить вопрос с ответом
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetQuestion()
    {
        return Ok(await _questionsService.GetQuestion());
    }

    [HttpPost]
    public async Task<IActionResult> PostUserAnswer([FromBody] UserAnswer answer)
    {
        await _questionsService.WriteUserAnswer(answer);
        return Ok();
    }
}
