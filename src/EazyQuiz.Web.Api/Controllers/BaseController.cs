using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Базовый контроллер
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : Controller
{
}
