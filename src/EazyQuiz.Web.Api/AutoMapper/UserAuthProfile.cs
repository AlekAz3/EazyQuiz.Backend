using AutoMapper;
using EazyQuiz.Models.Database;
using EazyQuiz.Models.DTO;
using System.Text;

namespace EazyQuiz.Web.Api;

public class UserAuthProfile : Profile
{
    public UserAuthProfile()
    {
        CreateMap<UserRegister, User>()
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password.PasswordHash)))
            .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password.PasswordSalt)))
            .ForMember(x => x.RegistrationTime, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<User, UserResponse>();
    }
}
