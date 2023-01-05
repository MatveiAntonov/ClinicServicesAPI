using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Queries.QueriesTypes
{
    public class GetAllServicesQuery : IRequest<IEnumerable<Service>> { }
}
