using MediatR;
using Management.Domain.Entities;

namespace Management.Application.ServiceCategories.Commands.CommandTypes
{
    public class CreateServiceCategoryCommand : IRequest<ServiceCategory>
    {
        public string ServiceCategoryName { get; set; } = string.Empty;
        public DateTime? TimeSlotSize { get; set; }    
    }
}
