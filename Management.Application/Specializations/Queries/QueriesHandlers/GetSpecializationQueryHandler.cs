using Management.Application.Interfaces;
using Management.Application.Specializations.Queries.QueriesTypes;
using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Services.Queries.QueriesHandlers;

public class GetSpecializationQueryHandler
    : IRequestHandler<GetSpecializationQuery, Specialization>
{
    private readonly ISpecializationRepository _specializationsRepository;
    public GetSpecializationQueryHandler(ISpecializationRepository specializationsRepository)
    {
        _specializationsRepository = specializationsRepository;
    }

    public async Task<Specialization> Handle(GetSpecializationQuery request, CancellationToken cancellationToken)
    {
        return await _specializationsRepository.GetSpecialization(request.SpecializationId, cancellationToken);
    }
}
