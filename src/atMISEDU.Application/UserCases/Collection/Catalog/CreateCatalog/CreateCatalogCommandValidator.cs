using FluentValidation;

namespace atMISEDU.Application.UserCases.Collection.Catalog.CreateCatalog;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
{
    public CreateCatalogCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Catalog name cannot be empty.")
            .MaximumLength(100).WithMessage("Catalog name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
