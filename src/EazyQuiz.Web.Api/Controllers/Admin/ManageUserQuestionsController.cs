using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

public class ManageUserQuestionsController : BaseController
{
    private readonly UsersQuestionService _service;

    public ManageUserQuestionsController(UsersQuestionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromQuery] UserQuestionFilter filter, CancellationToken token)
    {
        var result = await _service.GetByFilter(filter, token);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserQuestion([FromBody] UpdateUserQuestion question, CancellationToken token)
    {
        await _service.UpdateUserQuestion(question, token);
        return Ok();
    }
}
