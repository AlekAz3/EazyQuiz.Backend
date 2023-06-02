using EazyQuiz.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;

/// <summary>
///     Контроллер обратной связи
/// </summary>
public class FeedbackController : BaseController
{
    /// <inheritdoc cref="FeedbackService" />
    private readonly FeedbackService _service;

    /// <inheritdoc cref="CurrentUserService" />
    private readonly CurrentUserService _user;

    public FeedbackController(FeedbackService service, CurrentUserService user)
    {
        _service = service;
        _user = user;
    }

    /// <summary>
    ///     Получить коллекцию обратной связи от пользоватлей
    /// </summary>
    /// <param name="status">Статус </param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекцию обратной связи</returns>
    /// <remarks>Для администратора</remarks>
    [HttpGet]
    public async Task<IActionResult> GetFeedbacks([FromQuery] string status, CancellationToken token)
    {
        if (_user.GetUserRole() != "Admin")
        {
            return BadRequest();
        }

        var feedbacks = await _service.GetFeedback(status, token);
        return Ok(feedbacks);
    }

    /// <summary>
    ///     Отправить новую обратную связь
    /// </summary>
    /// <param name="request">Запрос на добавление</param>
    /// <param name="token">Токен отмены запроса</param>
    [HttpPost]
    public async Task<IActionResult> AddFeedbackFromUser([FromBody] FeedbackRequest request, CancellationToken token)
    {
        await _service.AddNewFeedback(request, token);

        return Ok();
    }

    /// <summary>
    ///     Обновить обратную связь
    /// </summary>
    /// <param name="feedbackUpdate">ЗАпрос на обновление</param>
    /// <param name="token">Токен отмены запроса</param>
    /// <remarks>Для администратора</remarks>
    [HttpPut]
    public async Task<IActionResult> UpdateFeedback([FromBody] FeedbackUpdateDTO feedbackUpdate,
        CancellationToken token)
    {
        if (_user.GetUserRole() != "Admin")
        {
            return BadRequest();
        }

        await _service.UpdateFeedbacks(feedbackUpdate, token);
        return Ok();
    }
}
