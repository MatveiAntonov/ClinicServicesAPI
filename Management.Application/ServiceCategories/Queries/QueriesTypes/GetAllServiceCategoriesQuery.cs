using Management.Domain.Entities;
using MediatR;

namespace Management.Application.ServiceCategories.Queries.QueriesTypes;

public class GetAllServiceCategoriesQuery : IRequest<IEnumerable<ServiceCategory>> { }
