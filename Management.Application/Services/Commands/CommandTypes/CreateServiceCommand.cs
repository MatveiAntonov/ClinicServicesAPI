using MediatR;
using Management.Domain.Entities;

namespace Management.Application.Services.Commands.CommandTypes
{
    public class CreateServiceCommand : IRequest<Service>
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public double? ServicePrice { get; set; }
        public int SpecializationId { get; set; }
    }
}
