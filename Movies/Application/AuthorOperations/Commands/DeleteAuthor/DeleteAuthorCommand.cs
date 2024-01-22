using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.DbOperations;

namespace Movies.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly MovieStoreDbContext dbContext;
        public int AuthorId {get; set;}
        public DeleteAuthorCommand(MovieStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle()
        {
            var author=dbContext.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Movie not found");
            }
            dbContext.Authors.Remove(author);
            dbContext.SaveChanges();
        }
    }
}