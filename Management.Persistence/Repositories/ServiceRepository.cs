using AutoMapper;
using Management.Application.Common.Exceptions;
using Management.Application.Interfaces;
using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Persistence.Repositories {
    public class ServiceRepository : IServiceRepository {
        private readonly ManagementDbContext _managementDbContext;
        private readonly IMapper _mapper;
        public ServiceRepository(ManagementDbContext context, IMapper mapper) {
            _managementDbContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Service>> GetAllServices(CancellationToken cancellationToken) 
        {
            return await _managementDbContext.Services
                    .Include(service => service.ServiceCategory)
                    .Include(service => service.Specialization)
                    .ToListAsync();
        }

        public async Task<Service> GetService(int id, CancellationToken cancellationToken) {
            var entity = await _managementDbContext.Services
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .FirstOrDefaultAsync(service => service.ServiceId == id);

            if (entity == null || entity.ServiceId != id)
            {
                throw new NotFoundException(nameof(Service), id);
            } 
            else
            {
                return entity;
            }
        }
        public async Task<Service> CreateService(Service request, CancellationToken cancellationToken) 
        {
            var category = _managementDbContext.ServiceCategories
                .FirstOrDefault(category => category.ServiceCategoryId == request.ServiceCategoryId);

            var specialization = _managementDbContext.Specializations
                .FirstOrDefault(specialization => specialization.SpecializationId == request.SpecializationId);


            if (category is not null && specialization is not null)
            {
                request.ServiceCategory = category;
                request.Specialization = specialization;

                _managementDbContext.Services.Add(request);
                await _managementDbContext.SaveChangesAsync(cancellationToken);

                return _managementDbContext.Services
                    .Include(service => service.ServiceCategory)
                    .Include(service => service.Specialization)
                    .FirstOrDefault(service => service.ServiceId == request.ServiceId)!;
            }
            else
            {
                throw new Exception(); // Add Exception
            }             
        }
        public async Task<Service> UpdateService(Service request, CancellationToken cancellationToken) 
        {
            var entity = await _managementDbContext.Services
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .FirstOrDefaultAsync(service => service.ServiceId == request.ServiceId, cancellationToken);
            
            var category = _managementDbContext.ServiceCategories
                .FirstOrDefault(category => category.ServiceCategoryId == request.ServiceCategoryId);

            var specialization = _managementDbContext.Specializations
                .FirstOrDefault(specialization => specialization.SpecializationId == request.SpecializationId);


            if (entity is null || entity.ServiceId != request.ServiceId || category is null || specialization is null)
            {
                throw new NotFoundException(nameof(Service), request.ServiceId);
            } 
            else
            {
                entity.ServiceCategoryId = request.ServiceCategoryId;
                entity.SpecializationId = request.SpecializationId;
                entity.ServiceCategory = request.ServiceCategory;
                entity.Specialization = request.Specialization;
                entity.ServiceName = request.ServiceName;
                entity.ServicePrice = request.ServicePrice;

                await _managementDbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }
        }

        public async Task<Service> DeleteService(int id, CancellationToken cancellationToken)
        {
            var entity = await _managementDbContext.Services
                .FirstOrDefaultAsync(service => service.ServiceId == id, cancellationToken);
            if (entity == null || entity.ServiceId != id)
            {
                throw new NotFoundException(nameof(Service), id);
            }
            else
            {
                _managementDbContext.Services.Remove(entity);
                await _managementDbContext.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }
    }
}
