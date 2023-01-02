using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Commands.CommandTypes
{
    public class DeleteServiceCategoryCommand : IRequest<ServiceCategory>
    {
        public int ServiceCategoryId { get; set; }
    }
}
