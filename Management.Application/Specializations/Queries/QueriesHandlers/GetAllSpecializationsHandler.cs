using Management.Application.Interfaces;
using Management.Application.Specializations.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services.Queries.QueriesHandlers
{
    public class GetAllSpecializationsHandler
        : IRequestHandler<GetAllSpecializationsQuery, IEnumerable<Specialization>>
    {
        private readonly ISpecializationRepository _specializationsRepository;
        public GetAllSpecializationsHandler(ISpecializationRepository specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }
        public async Task<IEnumerable<Specialization>> Handle(GetAllSpecializationsQuery request, CancellationToken cancellationToken)
        {
            return await _specializationsRepository.GetAllSpecializations(cancellationToken);
        }
    }
}
