using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        await _service.AddNewUserQuestionToQueue(userId, questionByUser, token);
        Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetHistoryByFilter([FromQuery] GetHistoryCommand command, CancellationToken token)
    {
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        var list = await _service.GetUsersQuestions(userId, command, token);
        return Ok(list);
    }
}
