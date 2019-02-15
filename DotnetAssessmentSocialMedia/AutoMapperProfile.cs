using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Dtos;
using Profile = AutoMapper.Profile;

namespace DotnetAssessmentSocialMedia
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserDto, User>()
                 .ForMember(dest => dest.Credentials, opt => opt.MapFrom(src => src.Credentials))
                 .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
                 .ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<Credentials, CredentialsDto>();
            
            CreateMap<Profile, ProfileDto>();

            CreateMap<Tweet, TweetDto>();

            CreateMap<HashTag, HashTagDto>();
            
            CreateMap<User, UserResponseDto>()
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => src.Credentials.Username)
                );
        }
    }
}