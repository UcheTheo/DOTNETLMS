using AutoMapper;
using LMS_ENTITIES.DbSet;
using LMS_ENTITIES.DTOs.Incoming.User;
using LMS_ENTITIES.DTOs.Outgoing.User;

namespace LMS_API.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<CreateUserDto, User>()
			.ForMember(
				dest => dest.Name,
				from => from.MapFrom(x => $"{x.Name}")
			)
			.ForMember(
				dest => dest.Email,
				from => from.MapFrom(x => $"{x.Email}")
			)
			.ForMember(
				dest => dest.Password,
				from => from.MapFrom(x => $"{x.Password}")
			);

		CreateMap<User, GetUserDto>()
			.ForMember(
				dest => dest.Name,
				from => from.MapFrom(x => $"{x.Name}")
			)
			.ForMember(
				dest => dest.Email,
				from => from.MapFrom(x => $"{x.Email}")
			)
			.ForMember(
				dest => dest.AvatarUrl,
				from => from.MapFrom(x => x.Avatar.Url)
			);

	}
	
}
