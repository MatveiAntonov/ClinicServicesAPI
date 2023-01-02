using AutoMapper;
using Management.Application.Interfaces;
using Management.Application.Specializations.Commands.CommandTypes;
using Management.Domain.Entities;
using MediatR;

namespace Management.Application.Specializations.Commands.CommandHandlers
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, Specialization>
    {
        private readonly ISpecializationRepository _specializationsRepository;
        private readonly IMapper _mapper;
        public UpdateSpecializationCommandHandler(ISpecializationRepository specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;

        }
        public async Task<Specialization> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = _mapper.Map<Specialization>(request); 
            return await _specializationsRepository.UpdateSpecialization(specialization, cancellationToken);
        }
    }
}
