using FluentValidation;
using Management.Application.ServiceCategories.Commands.CommandTypes;


namespace Management.Application.ServiceCategories.Commands.CommandValidators
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCategoryCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(createCommand => createCommand.ServiceCategoryName).NotEmpty().MaximumLength(350);
        }
    }
}
