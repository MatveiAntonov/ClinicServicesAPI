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

        public async Task<Service?> GetService(int id, CancellationToken cancellationToken) {
            return await _managementDbContext.Services
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .FirstOrDefaultAsync(service => service.ServiceId == id);
        }
        public async Task<Service?> CreateService(Service request, CancellationToken cancellationToken) 
        {
            var category = _managementDbContext.ServiceCategories
                .FirstOrDefault(category => category.ServiceCategoryId == request.ServiceCategoryId);

            var specialization = _managementDbContext.Specializations
                .FirstOrDefault(specialization => specialization.SpecializationId == request.SpecializationId);

            request.Specialization = specialization;
            request.ServiceCategory = category;

            _managementDbContext.Services.Add(request);
            await _managementDbContext.SaveChangesAsync(cancellationToken);

            return await _managementDbContext.Services
                    .Include(service => service.ServiceCategory)
                    .Include(service => service.Specialization)
                    .FirstOrDefaultAsync(service => service.ServiceId == request.ServiceId);
        }
        public async Task<Service?> UpdateService(Service request, CancellationToken cancellationToken) 
        {
            var entity = await _managementDbContext.Services
                .Include(service => service.ServiceCategory)
                .Include(service => service.Specialization)
                .FirstOrDefaultAsync(service => service.ServiceId == request.ServiceId, cancellationToken);
            
            var category = _managementDbContext.ServiceCategories
                .FirstOrDefault(category => category.ServiceCategoryId == request.ServiceCategoryId);

            var specialization = _managementDbContext.Specializations
                .FirstOrDefault(specialization => specialization.SpecializationId == request.SpecializationId);

            entity.ServiceCategoryId = request.ServiceCategoryId;
            entity.SpecializationId = request.SpecializationId;
            entity.ServiceCategory = request.ServiceCategory;
            entity.Specialization = request.Specialization;
            entity.ServicePrice = request.ServicePrice;
            entity.ServiceName = request.ServiceName;

            await _managementDbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<Service?> DeleteService(int id, CancellationToken cancellationToken)
        {
            var entity = await _managementDbContext.Services
                .FirstOrDefaultAsync(service => service.ServiceId == id, cancellationToken);
            
            _managementDbContext.Services.Remove(entity);

            await _managementDbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
