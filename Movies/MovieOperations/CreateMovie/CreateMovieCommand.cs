using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies;
using Movies.DbOperations;

namespace WebApi.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly MovieStoreDbContext dbContext;
        public CreateMovieCommand(MovieStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Handle()
        {
            var movie =dbContext.Movies.SingleOrDefault(x=> x.Title==Model.Title);
            if(movie is not null)
            {
                throw new InvalidOperationException("Movie is exist.");
            }
            movie = new Movie(){
                Title = Model.Title,
                PublishDate = Model.PublishDate,
                Language = Model.Language,
                GenreId = Model.GenreId

            };
        
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
        }

        public class CreateMovieModel
        {
            
            public string Title {get; set;}
            public int GenreId {get; set;}
            public string Language {get; set;}
            public DateTime PublishDate {get; set;}
        }
    }
}