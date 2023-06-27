using EazyQuiz.Models.DTO;
using EazyQuiz.Web.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EazyQuiz.Web.Api.Controllers;

/// <summary>
///     Контроллер обратной связи
/// </summary>
public class FeedbackController : BaseController
{
    /// <inheritdoc cref="FeedbackService" />
    private readonly FeedbackService _service;

    public FeedbackController(FeedbackService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Получить коллекцию обратной связи от пользоватлей
    /// </summary>
    /// <param name="status">Статус </param>
    /// <param name="token">Токен отмены запроса</param>
    /// <returns>Коллекцию обратной связи</returns>
    [HttpGet]
    [AdminOnly]
    public async Task<IActionResult> GetFeedbacks([FromQuery] string status, CancellationToken token)
    {
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
    [HttpPut]
    [AdminOnly]
    public async Task<IActionResult> UpdateFeedback([FromBody] FeedbackUpdateDTO feedbackUpdate,
        CancellationToken token)
    {
        await _service.UpdateFeedbacks(feedbackUpdate, token);
        return Ok();
    }
}
