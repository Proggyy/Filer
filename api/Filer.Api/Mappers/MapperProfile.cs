using AutoMapper;
using Filer.Api.DTOs;
using Filer.DataAccess;
using Filer.Domain.Domain;

namespace Filer.Api.Mappers;

public class MapperProfile : Profile{
    public MapperProfile()
    {
        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto,Post>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.CreationDate, y => y.MapFrom(z => DateTimeOffset.Now.ToUniversalTime()));
        CreateMap<PostEntity,Post>()
            .ForMember(x => x.Creator, y => y.MapFrom(z => z.UserEntity!));
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto,User>();
    }
}