using EazyQuiz.Models.DTO;

namespace EazyQuiz.Web.Api;
public interface IQuestionsService
{
    Task<QuestionResponse> GetQuestion();
    Task WriteUserAnswer(UserAnswer answer);
}
