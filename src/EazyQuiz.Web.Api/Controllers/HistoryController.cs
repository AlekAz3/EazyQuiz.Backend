using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;

public class HistoryController : BaseController
{
    private readonly HistoryService _service;

    public HistoryController(HistoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetHistoryByFilter([FromQuery] Guid userId, [FromQuery] AnswersGetHistoryCommand command, CancellationToken token)
    {
        var list = await _service.GetHistoryByFilter(userId, command, token);
        return Ok(list);
    }
}
