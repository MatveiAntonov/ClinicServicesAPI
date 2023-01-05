using Management.Application.Interfaces;
using Management.Application.Services.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.Queries.QueriesHandlers
{
    public class GetAllServicesHandler
        : IRequestHandler<GetAllServicesQuery, IEnumerable<Service>>
    {
        private readonly IServiceRepository _servicesRepository;
        public GetAllServicesHandler(IServiceRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            return await _servicesRepository.GetAllServices(cancellationToken);
        }
    }
}
