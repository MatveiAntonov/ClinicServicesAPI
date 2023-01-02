using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Specializations.Commands.CommandTypes
{
    public class UpdateSpecializationCommand : IRequest<Specialization>
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; } = String.Empty;
    }
}
