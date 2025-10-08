using FluentValidation;

using Repository.Entities;

namespace DomainServices.Validator
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.Categorie).NotEmpty().WithMessage("The category expense is required.")
                                     .MaximumLength(50).WithMessage("The category is limited to 50 characters.");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("The amount expense is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description expense is required.")
                                       .MaximumLength(1000).WithMessage("The description is limited to 1000 characters.");
        }
    }
}
