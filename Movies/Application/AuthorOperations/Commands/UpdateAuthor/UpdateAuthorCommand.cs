using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Movies.DbOperations;

namespace Movies.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly MovieStoreDbContext dbContext;
        public int AuthorId {get; set;}
        public UpdateAuthorModel Model {get; set;}
        public UpdateAuthorCommand(MovieStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle()
        {
            var author = dbContext.Authors.SingleOrDefault(x=> x.Id==AuthorId);
            if(author is null)
             {
                throw new InvalidOperationException("author not found");
            }
           if(dbContext.Authors.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
            {
                throw new InvalidOperationException("Aynı isimli film türü mevcut");
            }
            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name: Model.Name ;
            author.IsActive = Model.IsActive;
            dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; } = true;
    }
}