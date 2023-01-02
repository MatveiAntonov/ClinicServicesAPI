using Management.Application.Interfaces;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;
namespace Management.Application.ServiceCategories.Commands.CommandHandlers;

public class DeleteServiceCategoryCommandHandler
    : IRequestHandler<DeleteServiceCategoryCommand, ServiceCategory>
{
    private readonly IServiceCategoryRepository _servicesCategoryRepository;
    public DeleteServiceCategoryCommandHandler(IServiceCategoryRepository servicesCategoryRepository)
    {
        _servicesCategoryRepository = servicesCategoryRepository;
    }
    public async Task<ServiceCategory> Handle(DeleteServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _servicesCategoryRepository.DeleteServiceCategory(request.ServiceCategoryId, cancellationToken);
    }
}
