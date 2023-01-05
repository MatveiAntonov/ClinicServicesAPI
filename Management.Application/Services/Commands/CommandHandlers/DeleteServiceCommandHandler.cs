using Management.Application.Interfaces;
using Management.Application.Services.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.Commands.CommandHandlers;

public class DeleteServiceCommandHandler
    : IRequestHandler<DeleteServiceCommand, Service>
{
    private readonly IServiceRepository _servicesRepository;
    public DeleteServiceCommandHandler(IServiceRepository servicesRepository)
    {
        _servicesRepository = servicesRepository;
    }
    public async Task<Service> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        return await _servicesRepository.DeleteService(request.ServiceId, cancellationToken);
    }
}
