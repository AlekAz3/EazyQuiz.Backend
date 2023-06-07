using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Контролер по добавлению вопрос от пользователей
/// </summary>
public class AddUserQuestionController : BaseController
{
    /// <inheritdoc cref="UsersQuestionService" />
    private readonly UsersQuestionService _service;

    public AddUserQuestionController(UsersQuestionService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Добавить новый предложенный вопрос от пользователя в очередь
    /// </summary>
    /// <param name="questionByUser">Предложенный вопрос от пользователя</param>
    /// <param name="token">Токен отмены запроса</param>
    [HttpPost]
    public async Task<IActionResult> AddNewUserQuestionToQueue([FromBody] AddQuestionByUser questionByUser,
        CancellationToken token)
    {
        await _service.AddNewUserQuestionToQueue(questionByUser, token);
        return Ok();
    }

    /// <summary>
    ///     Получить историю предложенных игроком вопросов по фильтру
    /// </summary>
    /// <param name="command">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция предложенных вопросов</returns>
    [HttpGet]
    public async Task<IActionResult> GetHistoryByFilter([FromQuery] GetHistoryCommand command, CancellationToken token)
    {
        var list = await _service.GetUsersQuestions(command, token);
        return Ok(list);
    }
}
