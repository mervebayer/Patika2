using FluentValidation;

namespace Movies.MovieOperations.UpdateMovie;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>{

    public UpdateMovieCommandValidator()
    {
        RuleFor(command => command.MovieId).GreaterThan(0);
        RuleFor(command => command.Model.GenreId).GreaterThan(0);
        RuleFor(command => command.Model.Title).NotEmpty();
    }

}