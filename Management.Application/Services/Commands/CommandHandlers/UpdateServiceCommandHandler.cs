using Management.Application.Interfaces;
using Management.Application.Services.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;
using AutoMapper;

namespace Management.Application.Services.Commands.CommandHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Service>
    {
        private readonly IServiceRepository _servicesRepository;
        private readonly IMapper _mapper;
        public UpdateServiceCommandHandler(IServiceRepository servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;

        }
        public async Task<Service> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request);
            return await _servicesRepository.UpdateService(service, cancellationToken);
        }
    }
}
