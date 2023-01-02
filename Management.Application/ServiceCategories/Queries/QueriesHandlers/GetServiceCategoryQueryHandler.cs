using Management.Application.Interfaces;
using Management.Application.ServiceCategories.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Queries.QueriesHandlers;

public class GetServiceCategoryQueryHandler
    : IRequestHandler<GetServiceCategoryQuery, ServiceCategory>
{
    private readonly IServiceCategoryRepository _servicesCategoryRepository;
    public GetServiceCategoryQueryHandler(IServiceCategoryRepository servicesCategoryRepository)
    {
        _servicesCategoryRepository = servicesCategoryRepository;
    }

    public async Task<ServiceCategory> Handle(GetServiceCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _servicesCategoryRepository.GetServiceCategory(request.ServiceCategoryId, cancellationToken);
    }
}
