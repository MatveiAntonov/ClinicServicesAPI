using Management.Application.Interfaces;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;
using AutoMapper;

namespace Management.Application.ServiceCategories.Commands.CommandHandlers
{
    public class UpdateServiceCategoryCommandHandler 
        : IRequestHandler<UpdateServiceCategoryCommand, ServiceCategory>
    {
        private readonly IServiceCategoryRepository _servicesCategoryRepository;
        private readonly IMapper _mapper;
        public UpdateServiceCategoryCommandHandler(IServiceCategoryRepository servicesCategoryRepository, IMapper mapper)
        {
            _servicesCategoryRepository = servicesCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ServiceCategory> Handle(UpdateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var serviceCategory = _mapper.Map<ServiceCategory>(request);
            return await _servicesCategoryRepository.UpdateServiceCategory(serviceCategory, cancellationToken);
        }
    }
}
