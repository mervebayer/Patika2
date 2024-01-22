using AutoMapper;
using Movies.Entities;
using Movies.Application.MovieOperations.GetById;
using Movies.Application.MovieOperations.GetMovies;
using static Movies.Application.MovieOperations.CreateMovie.CreateMovieCommand;

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