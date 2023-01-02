using Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces {
    public interface IServiceCategoryRepository {
        Task<IEnumerable<ServiceCategory>> GetAllServiceCategories(CancellationToken cancellationToken);
        Task<ServiceCategory> GetServiceCategory(int id, CancellationToken cancellationToken);
        Task<ServiceCategory> CreateServiceCategory(ServiceCategory request, CancellationToken cancellationToken);
        Task<ServiceCategory> UpdateServiceCategory(ServiceCategory request, CancellationToken cancellationToken);
        Task<ServiceCategory> DeleteServiceCategory(int id, CancellationToken cancellationToken);
    }
}
