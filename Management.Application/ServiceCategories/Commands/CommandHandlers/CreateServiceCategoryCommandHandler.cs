using MediatR;
using Management.Domain.Entities;
using Management.Application.Interfaces;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using AutoMapper;

namespace Management.Application.ServiceCategories.Commands.CommandHandlers
{
    public class CreateServiceCategoryCommandHandler
        : IRequestHandler<CreateServiceCategoryCommand, ServiceCategory>
    {

        private readonly IServiceCategoryRepository _servicesCategoryRepository;
        private readonly IMapper _mapper;

        public CreateServiceCategoryCommandHandler(IServiceCategoryRepository servicesCategoryRepository, IMapper mapper)
        {
            _servicesCategoryRepository = servicesCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceCategory> Handle(CreateServiceCategoryCommand request,
            CancellationToken cancellationToken)
        {

            var serviceCategory = _mapper.Map<ServiceCategory>(request);
            return await _servicesCategoryRepository.CreateServiceCategory(serviceCategory, cancellationToken);
        }
    }
}
