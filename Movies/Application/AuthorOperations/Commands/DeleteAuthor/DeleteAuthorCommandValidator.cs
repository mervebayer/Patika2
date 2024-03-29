using FluentValidation;

namespace Movies.Application.AuthorOperations.Command.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>{

    public DeleteAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId).GreaterThan(0);
    }

}