using AutoMapper;
using Movies.DbOperations;

namespace Movies.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId{get; set;}
        private readonly MovieStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetAuthorDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public  AuthorDetailViewModel  Handle(){
            var author = dbContext.Authors.Where(x => x.IsActive && x.Id == AuthorId).OrderBy(x => x.Id);
            if(author is null){
                throw new InvalidOperationException("Author türü bulunamadı");
            }
            return mapper.Map<AuthorDetailViewModel>(author);
        }
    }

    public class AuthorDetailViewModel{
        public int Id {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public DateTime DateOfBirth {get; set;}
    }
}