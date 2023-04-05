using AutoMapper;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using EazyQuiz.Models.DTO.UsersQuestion;
using System.Text;

namespace EazyQuiz.Web.Api;

/// <summary>
/// Профиль маппинга
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserAnswer, UsersAnswers>()
            .ForMember(x => x.AnswerTime, opt => opt.MapFrom(src => DateTimeOffset.Now));

        CreateMap<Answers, Answer>()
            .ForMember(x => x.AnswerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.AnswerText, opt => opt.MapFrom(src => src.Text));

        CreateMap<UserRegister, User>()
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password.PasswordHash)))
            .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password.PasswordSalt)))
            .ForMember(x => x.RegistrationTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
        CreateMap<User, UserResponse>();

        CreateMap<QuestionByUserResponse, UsersQuesions>().ReverseMap();

        CreateMap<AddQuestionByUser, UsersQuesions>()
            .ForMember(x => x.LastUpdate, opt => opt.MapFrom(opt => DateTimeOffset.Now))
            .ForMember(x => x.Status, opt => opt.MapFrom(opt => "Новый"));

    }
}
