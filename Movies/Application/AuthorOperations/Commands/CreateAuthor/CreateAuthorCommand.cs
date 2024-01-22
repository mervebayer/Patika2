using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movies;
using Movies.DbOperations;
using Movies.Entities;

namespace Movies.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly MovieStoreDbContext dbContext;
        private readonly IMapper mapper;
        public CreateAuthorCommand(MovieStoreDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var author =dbContext.Authors.SingleOrDefault(x=> x.Name==Model.Name);
            if(author is not null)
            {
                throw new InvalidOperationException("author is exist.");
            }
            author = mapper.Map<Author>(Model);
        
            dbContext.Authors.Add(author);
            dbContext.SaveChanges();
        }

        public class CreateAuthorModel
        {
            
            public string Name {get; set;}
            public string Surname {get; set;}
            public DateTime DateofBirth {get; set;}
            
        }
    }
}