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

    /// <summary>
    /// Получить коллекцию вопросов по фильтру
    /// </summary>
    /// <param name="command">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция вопросов с ответами</returns>
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
        await _questionsService.WriteUserAnswer(answer);
        return Ok();
    }

    /// <summary>
    /// Добавить вопрос с админки
    /// </summary>
    /// <remarks>Для администратора</remarks>
    [HttpPost(nameof(Add))]
    public async Task<IActionResult> Add([FromBody] QuestionInputDTO question)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _questionsService.AddQuestion(question);
        _logger.LogInformation("Новый вопрос: \"{QuestionText}\", был добавлен в базу данных", question.Text);
        return Ok();
    }
}
