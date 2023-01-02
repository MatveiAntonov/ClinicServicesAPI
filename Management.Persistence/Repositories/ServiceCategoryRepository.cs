using Management.Application.Common.Exceptions;
using Management.Application.Interfaces;
using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Management.Persistence.Repositories;

public class ServiceCategoryRepository : IServiceCategoryRepository
{
    private readonly ManagementDbContext _managementDbContext;
    private readonly IMapper _mapper;
    public ServiceCategoryRepository(ManagementDbContext context, IMapper mapper)
    {
        _managementDbContext = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceCategory>> GetAllServiceCategories(CancellationToken cancellationToken)
    {
        return await _managementDbContext.ServiceCategories.ToListAsync();
    }

    public async Task<ServiceCategory> GetServiceCategory(int id, CancellationToken cancellationToken)
    {
        var entity = await _managementDbContext.ServiceCategories
            .FirstOrDefaultAsync(serviceCategory =>
            serviceCategory.ServiceCategoryId == id);

        if (entity == null || entity.ServiceCategoryId != id)
        {
            throw new NotFoundException(nameof(ServiceCategory), id);
        } else
        {
            return entity;
        }
    }

    public async Task<ServiceCategory> CreateServiceCategory(ServiceCategory request, CancellationToken cancellationToken)
    {
        var entity = await _managementDbContext.ServiceCategories
            .AsNoTracking()
            .FirstOrDefaultAsync(category => 
             category.ServiceCategoryName == request.ServiceCategoryName);
        if (entity is null)
        {
            _managementDbContext.ServiceCategories.Add(request);
            await _managementDbContext.SaveChangesAsync(cancellationToken);
            return request;
        }
        else
        {
            throw new Exception(); // Add Exception
        }
        
    }

    public async Task<ServiceCategory> UpdateServiceCategory(ServiceCategory request, CancellationToken cancellationToken)
    {
        var entity = await _managementDbContext.ServiceCategories
            .FirstOrDefaultAsync(serviceCategory =>
            serviceCategory.ServiceCategoryId == request.ServiceCategoryId, cancellationToken);

        if (entity == null || entity.ServiceCategoryId != request.ServiceCategoryId)
        {
            throw new NotFoundException(nameof(ServiceCategory), request.ServiceCategoryId);
        } else
        {
            entity.ServiceCategoryName = request.ServiceCategoryName;
            entity.TimeSlotSize = request.TimeSlotSize;

            await _managementDbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }

    public async Task<ServiceCategory> DeleteServiceCategory(int id, CancellationToken cancellationToken)
    {
        var entity = await _managementDbContext.ServiceCategories
            .FirstOrDefaultAsync(serviceCategory =>
            serviceCategory.ServiceCategoryId == id, cancellationToken);
        if (entity == null || entity.ServiceCategoryId != id)
        {
            throw new NotFoundException(nameof(ServiceCategory), id);
        } else
        {
            _managementDbContext.ServiceCategories.Remove(entity);
            await _managementDbContext.SaveChangesAsync(cancellationToken);
        }
        return entity;
    }
}
