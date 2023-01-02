using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Commands.CommandTypes
{
    public class UpdateServiceCommand : IRequest<Service>
    {
        public int ServiceId { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public double? ServicePrice { get; set; }
        public int? SpecializationId { get; set; }
    }
}
