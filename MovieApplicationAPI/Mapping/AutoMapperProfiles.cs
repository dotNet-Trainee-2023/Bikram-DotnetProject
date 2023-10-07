using AutoMapper;
using MovieAppAPI.Dto;

using MovieAppDomain;

namespace MovieAppAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();
            CreateMap<MovieCreateDto, Movie>().ReverseMap();

            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();

            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CommentCreateDto, Comment>().ReverseMap();

        }
    }
}
