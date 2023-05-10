using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        var result = await _service.GetByFilter(filter, token);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserQuestion([FromBody] UpdateUserQuestion question, CancellationToken token)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _service.UpdateUserQuestion(question, token);
        return Ok();
    }
}
