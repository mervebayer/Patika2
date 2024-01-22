using FluentValidation;
using Movies.Application.AuthorOperations.Command.UpdateAuthor;

namespace Movies.Application.GenreOperations.Command.UpdateGenre;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>{

    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
    }

}