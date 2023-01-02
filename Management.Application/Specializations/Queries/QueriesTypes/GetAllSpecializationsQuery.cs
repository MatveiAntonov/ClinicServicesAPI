using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Specializations.Queries.QueriesTypes
{
    public class GetAllSpecializationsQuery : IRequest<IEnumerable<Specialization>> { }
}
