using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Queries.QueriesTypes;

public class GetServiceCategoryQuery : IRequest<ServiceCategory>
{
    public int ServiceCategoryId { get; set; }
}

