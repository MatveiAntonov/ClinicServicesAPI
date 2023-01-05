using FluentValidation;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.ServiceCategories.Commands.CommandValidators
{
    public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCategoryCommand>
    {
        public DeleteServiceCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.ServiceCategoryId).NotNull();
        }
    }
}
