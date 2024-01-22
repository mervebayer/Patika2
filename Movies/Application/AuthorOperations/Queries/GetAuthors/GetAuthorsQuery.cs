using AutoMapper;
using Movies.DbOperations;

namespace Movies.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly MovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetAuthorsQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public  List<AuthorsViewModel>  Handle(){
            var authors = dbContext.Authors.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<AuthorsViewModel> returnObj = mapper.Map<List<AuthorsViewModel>>(authors);
            return returnObj;
        }
    }

    public class AuthorsViewModel{
        public int Id {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public DateTime DateOfBirth {get; set;}
    }
}