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

    public QuestionsController(QuestionsService questionsService)
    {
        _questionsService = questionsService;
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
