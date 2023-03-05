using AutoMapper;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;

namespace EazyQuiz.Web.Api;

public class UserAnswerProfile : Profile
{
    public UserAnswerProfile()
    {
        CreateMap<UserAnswer, UsersAnswers>();
        CreateMap<Answers, Answer>()
            .ForMember(x => x.AnswerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.AnswerText, opt => opt.MapFrom(src => src.Text));
    }
}
