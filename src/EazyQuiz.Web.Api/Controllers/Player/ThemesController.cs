using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EazyQuiz.Web.Api;


public class ThemesController : BaseController
{
    private readonly ThemesService _service;

    public ThemesController(ThemesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetThemes(CancellationToken token)
    {
        var themes = await _service.GetAll(token);
        return Ok(themes);
    }

    [HttpPost]
    public async Task<IActionResult> AddTheme([FromBody] string name, CancellationToken token)
    {
        var role = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
        if (role != "Admin")
        {
            return BadRequest();
        }
        await _service.AddTheme(name, token);
        return Ok();
    }
}
