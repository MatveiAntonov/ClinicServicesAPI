using FluentValidation;
using Management.Application.Services.Commands.CommandTypes;

namespace Management.Application.Services.Commands.CommandValidators
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.ServiceId).NotNull();
            RuleFor(updateCommand => updateCommand.ServiceName).NotEmpty().MaximumLength(350);
            RuleFor(updateCommand => updateCommand.ServicePrice).NotNull();
            RuleFor(updateCommand => updateCommand.ServiceCategoryId).NotNull();
            RuleFor(updateCommand => updateCommand.SpecializationId).NotNull();
        }
    }
}
