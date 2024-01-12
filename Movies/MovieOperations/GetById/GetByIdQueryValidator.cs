using FluentValidation;

namespace Movies.MovieOperations.GetById;

public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>{

    public GetByIdQueryValidator()
    {
        RuleFor(query => query.MovieId).GreaterThan(0);
    }

}