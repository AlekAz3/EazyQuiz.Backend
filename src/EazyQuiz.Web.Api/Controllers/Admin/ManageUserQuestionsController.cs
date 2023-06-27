using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Контроллер для управления предложенными вопросами от игроков
/// </summary>
[AdminOnly]
public class ManageUserQuestionsController : BaseController
{
    /// <inheritdoc cref="UsersQuestionService" />
    private readonly UsersQuestionService _service;

    public ManageUserQuestionsController(UsersQuestionService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Получить коллекцию предложенных вопросов от игроков по фильтру
    /// </summary>
    /// <param name="filter">Фильтр</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекция вопросов</returns>
    /// <remarks>Для администратора</remarks>
    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] UserQuestionFilter filter, CancellationToken token)
    {
        var result = await _service.GetByFilter(filter, token);
        return Ok(result);
    }

    /// <summary>
    ///     Обновить вопрос предложенный от пользователя
    /// </summary>
    /// <param name="question">вопрос который необходимо обновить</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Для администратора</remarks>
    [HttpPut]
    public async Task<IActionResult> UpdateUserQuestion([FromBody] UpdateUserQuestion question, CancellationToken token)
    {
        await _service.UpdateUserQuestion(question, token);
        return Ok();
    }
}
