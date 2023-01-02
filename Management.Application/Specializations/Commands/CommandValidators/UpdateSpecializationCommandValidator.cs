using FluentValidation;
using Management.Application.Specializations.Commands.CommandTypes;

namespace Management.Application.Specializations.Commands.CommandValidators
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.SpecializationId).NotNull();
            RuleFor(updateCommand => updateCommand.SpecializationName).NotEmpty().MaximumLength(350);
        }
    }
}
