using AutoMapper;
using EazyQuiz.Data.Entities;
using EazyQuiz.Models.DTO;

namespace EazyQuiz.Web.Api;

/// <summary>
///     Профиль маппинга
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserAnswer, UsersAnswer>()
            .ForMember(x => x.AnswerTime, opt => opt.MapFrom(src => DateTimeOffset.Now));

        CreateMap<Answer, AnswerDTO>()
            .ForMember(x => x.AnswerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.AnswerText, opt => opt.MapFrom(src => src.Text));

        CreateMap<UserRegister, User>()
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.Password.PasswordHash))
            .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(src => src.Password.PasswordSalt))
            .ForMember(x => x.LastActiveTime, opt => opt.MapFrom(src => DateTimeOffset.Now));
        CreateMap<User, UserResponse>();

        CreateMap<QuestionByUserResponse, UsersQuestions>().ReverseMap();
        CreateMap<UserQuestionResponse, UsersQuestions>().ReverseMap();

        CreateMap<Theme, ThemeResponse>().ReverseMap();
        CreateMap<Theme, ThemeResponseWithFlag>().ReverseMap();

        CreateMap<AddQuestionByUser, UsersQuestions>()
            .ForMember(x => x.LastUpdate, opt => opt.MapFrom(opt => DateTimeOffset.Now))
            .ForMember(x => x.Status, opt => opt.MapFrom(opt => "Новый"))
            .ForMember(x => x.UserId, opt => opt.MapFrom<CurrentUserResolver>());

        CreateMap<User, PublicUserInfo>().ReverseMap();

        CreateMap<FeedbackRequest, Feedback>()
            .ForMember(x => x.Status, opt => opt.MapFrom(x => "Новый"))
            .ForMember(x => x.UserId, opt => opt.MapFrom<CurrentUserResolver>());

        CreateMap<Feedback, FeedbackResponse>();
    }
}
