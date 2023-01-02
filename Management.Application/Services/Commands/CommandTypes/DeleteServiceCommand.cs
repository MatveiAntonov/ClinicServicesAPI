using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Commands.CommandTypes
{
    public class DeleteServiceCommand : IRequest<Service>
    {
        public int ServiceId { get; set; }
    }
}
