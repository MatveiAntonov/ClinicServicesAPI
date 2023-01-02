using Management.Application.Interfaces;
using Management.Application.Specializations.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Specializations.Commands.CommandHandlers;

public class DeleteSpecializationCommandHandler
    : IRequestHandler<DeleteSpecializationCommand, Specialization>
{
    private readonly ISpecializationRepository _specializationsRepository;
    public DeleteSpecializationCommandHandler(ISpecializationRepository specializationsRepository)
    {
        _specializationsRepository = specializationsRepository;
    }
    public async Task<Specialization> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        return await _specializationsRepository.DeleteSpecialization(request.SpecializationId, cancellationToken);
    }
}
