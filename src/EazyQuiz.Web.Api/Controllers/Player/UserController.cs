using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Контроллер для управления пользователями
/// </summary>
public class UserController : BaseController
{
    /// <inheritdoc cref="UserService" />
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Сменить ник
    /// </summary>
    [HttpPost("username")]
    public async Task<IActionResult> ChangeUsername([FromBody] string newUsername, CancellationToken cancellationToken)
    {
        await _service.ChangeUsername(newUsername, cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Сменить пароль
    /// </summary>
    [HttpPost("password")]
    public async Task<IActionResult> ChangePassword([FromBody] UserPassword newPassword,
        CancellationToken cancellationToken)
    {
        await _service.ChangePassword(newPassword, cancellationToken);
        return Ok();
    }
}
