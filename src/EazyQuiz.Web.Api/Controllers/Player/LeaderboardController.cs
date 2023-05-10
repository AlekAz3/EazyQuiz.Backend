using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;

public class LeaderboardController : BaseController
{
    private readonly LeaderboardService _service;
    private readonly ILogger<LeaderboardController> _log;

    public LeaderboardController(LeaderboardService service, ILogger<LeaderboardController> log)
    {
        _service = service;
        _log = log;
    }

    [HttpGet]
    public async Task<IActionResult> GetByFilter([FromRoute] LeaderboardRequest filter, CancellationToken token)
    {
        var users = await _service.GetByFilter(filter, token);
        _log.LogInformation("Get Leaderboard");
        return Ok(users);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUser(CancellationToken token)
    {
        var userId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        var score = await _service.GetCurrentUserScore(userId, token);
        _log.LogInformation("GetCurrentUserScore {UserId}, {Score}", userId, score);
        return Ok(score);
    }
}
