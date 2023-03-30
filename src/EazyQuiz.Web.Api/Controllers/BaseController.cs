using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : Controller
{
}
