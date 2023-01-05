using Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces {
    public interface IServiceRepository {
        Task<IEnumerable<Service>> GetAllServices(CancellationToken cancellationToken);
        Task<Service> GetService(int id, CancellationToken cancellationToken);
        Task<Service> CreateService(Service service, CancellationToken cancellationToken);
        Task<Service> UpdateService(Service service, CancellationToken cancellationToken);
        Task<Service> DeleteService(int id, CancellationToken cancellationToken);
    }
}
