using AutoMapper;
using FluentValidation;
using Movies.DbOperations;

namespace Movies.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator: AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(q => q.AuthorId).GreaterThan(0);
        }
    }

}