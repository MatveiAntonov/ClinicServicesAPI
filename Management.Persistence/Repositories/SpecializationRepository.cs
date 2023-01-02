using Management.Application.Common.Exceptions;
using Management.Application.Interfaces;
using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Persistence.Repositories {
    public class SpecializationRepository : ISpecializationRepository {
        
        private readonly ManagementDbContext _managementDbContext;
        public SpecializationRepository(ManagementDbContext context) {
            _managementDbContext = context;
        }
        public async Task<IEnumerable<Specialization>> GetAllSpecializations(CancellationToken cancellationToken) {
            return await _managementDbContext.Specializations.ToListAsync();
        }

        public async Task<Specialization> GetSpecialization(int id, CancellationToken cancellationToken) {
            var entity = await _managementDbContext.Specializations
                .FirstOrDefaultAsync(specialization => specialization.SpecializationId == id);

            if (entity == null || entity.SpecializationId != id)
            {
                throw new NotFoundException(nameof(Specialization), id);
            } 
            else
            {
                return entity;
            }
        }

        public async Task<Specialization> CreateSpecialization(Specialization request, CancellationToken cancellationToken) {
            var entity = await _managementDbContext.Specializations
                .AsNoTracking()
                .FirstOrDefaultAsync(specialization =>
                specialization.SpecializationName == request.SpecializationName);
            if (entity is null)
            {
                _managementDbContext.Specializations.Add(request);
                await _managementDbContext.SaveChangesAsync(cancellationToken);
                return request;
            }
            else
            {
                throw new Exception(); // Add Exception
            }
        }

        public async Task<Specialization> UpdateSpecialization(Specialization request, CancellationToken cancellationToken) {
            var entity = await _managementDbContext.Specializations
                .FirstOrDefaultAsync(service => service.SpecializationId == request.SpecializationId, cancellationToken);

            if (entity == null || entity.SpecializationId != request.SpecializationId)
            {
                throw new NotFoundException(nameof(Specialization), request.SpecializationId);
            }
            else
            {
                entity.SpecializationName = request.SpecializationName;
                await _managementDbContext.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

        public async Task<Specialization> DeleteSpecialization(int id, CancellationToken cancellationToken) {
            var entity = await _managementDbContext.Specializations
                .FirstOrDefaultAsync(service => service.SpecializationId == id, cancellationToken);
            if (entity == null || entity.SpecializationId != id)
            {
                throw new NotFoundException(nameof(Specialization), id);
            }
            else
            {
                _managementDbContext.Specializations.Remove(entity);
                await _managementDbContext.SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

    }
}
