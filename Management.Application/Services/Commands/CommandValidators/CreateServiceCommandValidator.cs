using FluentValidation;
using Management.Application.Services.Commands.CommandTypes;


namespace Management.Application.Services.Commands.CommandValidators
{
    public class CreateSpecializationCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateSpecializationCommandValidator()
        {
            RuleFor(createCommand => createCommand.ServiceCategoryId).NotNull();
            RuleFor(createCommand => createCommand.ServiceName).NotEmpty();
            RuleFor(createCommand => createCommand.ServicePrice).NotNull();
            RuleFor(createCommand => createCommand.SpecializationId).NotNull();
        }
    }
}
