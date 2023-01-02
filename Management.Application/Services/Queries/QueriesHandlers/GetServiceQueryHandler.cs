using Management.Application.Interfaces;
using Management.Application.Services.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Queries.QueriesHandlers;

public class GetServiceQueryHandler
    : IRequestHandler<GetServiceQuery, Service>
{
    private readonly IServiceRepository _servicesRepository;
    public GetServiceQueryHandler(IServiceRepository servicesRepository)
    {
        _servicesRepository = servicesRepository;
    }

    public async Task<Service> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        return await _servicesRepository.GetService(request.ServiceId, cancellationToken);
    }
}
