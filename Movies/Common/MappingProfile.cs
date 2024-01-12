using AutoMapper;
using Movies.MovieOperations.GetById;
using static Movies.MovieOperations.CreateMovie.CreateMovieCommand;

namespace Movies.Common
{
    public class MappingProfile : Profile{
        public MappingProfile(){
            CreateMap<CreateMovieModel,Movie>();
            // CreateMap<Movie, MovieDetailViewModel>();
        }
    }
}