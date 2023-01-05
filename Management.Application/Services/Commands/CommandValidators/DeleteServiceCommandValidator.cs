using FluentValidation;
using Management.Application.Services.Commands.CommandTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.Commands.CommandValidators
{
    public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteSpecializationCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.ServiceId).NotNull();
        }
    }
}
