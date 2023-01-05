using MediatR;
using Management.Domain.Entities;

namespace Management.Application.Specializations.Commands.CommandTypes
{
    public class CreateSpecializationCommand : IRequest<Specialization>
    {
        public string SpecializationName { get; set; } = String.Empty;
    }
}
