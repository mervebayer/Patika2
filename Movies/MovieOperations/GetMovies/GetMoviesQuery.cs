using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies;
using Movies.DbOperations;
using WebApi.Common;

namespace WebApi.MovieOperations.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly MovieStoreDbContext dbContext;

        public GetMoviesQuery(MovieStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = dbContext.Movies.OrderBy(x=>x.Id).ToList<Movie>();
            List<MoviesViewModel> vm= new List<MoviesViewModel>();
            foreach(var movie in movieList)
            {
                vm.Add(new MoviesViewModel(){
                    Title=movie.Title,
                    Genre=((GenreEnum)movie.GenreId).ToString(),
                    PublishDate=movie.PublishDate.Date.ToString("dd/MM/yyy"),
                    Language=movie.Language
                });
            }
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title {get; set;}
        public string Genre {get; set;}
        public string Language {get; set;}
        public string PublishDate {get; set;}
    }
}