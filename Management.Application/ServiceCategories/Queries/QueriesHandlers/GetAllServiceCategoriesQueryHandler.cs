using Management.Application.Interfaces;
using Management.Application.ServiceCategories.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Queries.QueriesHandlers;

public class GetAllServiceCategoriesQueryHandler
    : IRequestHandler<GetAllServiceCategoriesQuery, IEnumerable<ServiceCategory>>
{
    private readonly IServiceCategoryRepository _servicesCategoryRepository;
    public GetAllServiceCategoriesQueryHandler(IServiceCategoryRepository servicesCategoryRepository)
    {
        _servicesCategoryRepository = servicesCategoryRepository;
    }
    public async Task<IEnumerable<ServiceCategory>> Handle(GetAllServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _servicesCategoryRepository.GetAllServiceCategories(cancellationToken);
    }
}
