using FluentValidation;
using Management.Application.Specializations.Commands.CommandTypes;


namespace Management.Application.Specializations.Commands.CommandValidators
{
    public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationCommandValidator()
        {
            RuleFor(createCommand => createCommand.SpecializationName).NotEmpty();
        }
    }
}
