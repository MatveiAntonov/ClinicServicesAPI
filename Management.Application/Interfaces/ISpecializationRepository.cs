using Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces {
    public interface ISpecializationRepository {
        Task<IEnumerable<Specialization?>> GetAllSpecializations(CancellationToken cancellationToken);
        Task<Specialization?> GetSpecialization(int id, CancellationToken cancellationToken);
        Task<Specialization?> CreateSpecialization(Specialization specialization, CancellationToken cancellationToken);
        Task<Specialization?> UpdateSpecialization(Specialization specialization, CancellationToken cancellationToken);
        Task<Specialization?> DeleteSpecialization(int id, CancellationToken cancellationToken);
    }
}
