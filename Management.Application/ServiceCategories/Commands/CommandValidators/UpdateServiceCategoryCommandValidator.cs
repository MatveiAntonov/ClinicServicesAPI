using FluentValidation;
using Management.Application.ServiceCategories.Commands.CommandTypes;

namespace Management.Application.ServiceCategories.Commands.CommandValidators
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCategoryCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.ServiceCategoryId).NotNull();
            RuleFor(updateCommand => updateCommand.ServiceCategoryName).NotEmpty().MaximumLength(350);
            RuleFor(updateCommand => updateCommand.TimeSlotSize).NotEmpty();
        }
    }
}
