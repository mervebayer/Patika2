using AutoMapper;
using Movies.Entities;
using Movies.Application.MovieOperations.Queries.GetById;
using Movies.Application.MovieOperations.Queries.GetMovies;
using static Movies.Application.MovieOperations.Command.CreateMovie.CreateMovieCommand;

namespace Movies.Common
{
    public class MappingProfile : Profile{
        public MappingProfile(){
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Movie,MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}