using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Commands.CommandTypes
{
    public class UpdateServiceCategoryCommand : IRequest<ServiceCategory>
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; } = string.Empty;
        public DateTime? TimeSlotSize { get; set; }
    }
}
