using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Контролер по добавлению вопрос от пользователей
/// </summary>
public class AddUserQuestionController : BaseController
{
    private readonly UsersQuestionService _service;

    public AddUserQuestionController(UsersQuestionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task AddNewUserQuestionToQueue([FromBody] AddQuestionByUser questionByUser, CancellationToken token)
    {
        await _service.AddNewUserQuestionToQueue(questionByUser, token);
        Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetHistoryByFilter([FromQuery] Guid userId, [FromQuery] GetHistoryCommand command, CancellationToken token)
    {
        var list = await _service.GetUsersQuestions(userId, command, token);
        return Ok(list);
    }
}
