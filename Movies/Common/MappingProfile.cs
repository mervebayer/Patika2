using AutoMapper;
using Movies.Entities;
using Movies.Application.MovieOperations.Queries.GetById;
using Movies.Application.MovieOperations.Queries.GetMovies;
using static Movies.Application.MovieOperations.Command.CreateMovie.CreateMovieCommand;
using Movies.Application.GenreOperations.Queries.GetGenres;
using Movies.Application.GenreOperations.Queries.GetGenreDetail;
using static Movies.Application.AuthorOperations.Command.CreateAuthor.CreateAuthorCommand;
using Movies.Application.AuthorOperations.Queries.GetAuthors;
using Movies.Application.AuthorOperations.Queries.GetAuthorDetail;

namespace Movies.Common
{
    public class MappingProfile : Profile{
        public MappingProfile(){
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                                         .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Movie,MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
        }
    }
}