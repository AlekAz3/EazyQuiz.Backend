using EazyQuiz.Web.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class QuestionsController : Controller
{
    private readonly DataContext _dataContext;
    private readonly ILogger<QuestionsController> _log;

    public QuestionsController(DataContext dataContext, ILogger<QuestionsController> logger)
    {
        _dataContext = dataContext;
        _log = logger;
    }

    [HttpGet]
    public JsonResult GetAllQuestions()
    {
        var result = _dataContext.Questions.ToList();
        _log.LogInformation("GetAllQuestions");
        return new JsonResult(result);
    }

}
