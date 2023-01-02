using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Specializations.Commands.CommandTypes
{
    public class DeleteSpecializationCommand : IRequest<Specialization>
    {
        public int SpecializationId { get; set; }
    }
}
