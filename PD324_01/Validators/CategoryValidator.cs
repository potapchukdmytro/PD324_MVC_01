using FluentValidation;
using PD324_01.Models;

namespace PD324_01.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не може бути порожнім")
                .NotNull().WithMessage("Поле не може бути порожнім")
                .MinimumLength(2).WithMessage("Ім'я повинне містити мінімум 2 літери");
        }
    }
}
