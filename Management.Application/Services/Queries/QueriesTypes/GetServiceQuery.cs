using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Queries.QueriesTypes;

    public class GetServiceQuery : IRequest<Service>
    {
        public int ServiceId { get; set; }
    }

