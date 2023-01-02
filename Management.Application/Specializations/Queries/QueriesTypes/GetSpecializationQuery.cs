using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Specializations.Queries.QueriesTypes;

    public class GetSpecializationQuery : IRequest<Specialization>
    {
        public int SpecializationId { get; set; }
    }

