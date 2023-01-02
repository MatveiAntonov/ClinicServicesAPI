using FluentValidation;
using Management.Application.Specializations.Commands.CommandTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Specializations.Commands.CommandValidators
{
    public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        public DeleteSpecializationCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.SpecializationId).NotNull();
        }
    }
}
