using MediatR;
using Management.Domain.Entities;
using Management.Application.Interfaces;
using Management.Application.Services.Commands.CommandTypes;
using AutoMapper;

namespace Management.Application.Services.Commands.CommandHandlers
{
    public class CreateServiceCommandHandler
        : IRequestHandler<CreateServiceCommand, Service>
    {

        private readonly IServiceRepository _servicesRepository;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IServiceRepository servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<Service> Handle(CreateServiceCommand request,
            CancellationToken cancellationToken)
        {

            var service = _mapper.Map<Service>(request);
            return await _servicesRepository.CreateService(service, cancellationToken);
        }
    }
}
