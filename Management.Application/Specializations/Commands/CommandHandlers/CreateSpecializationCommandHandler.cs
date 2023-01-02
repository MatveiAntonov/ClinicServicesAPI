using MediatR;
using Management.Domain.Entities;
using Management.Application.Interfaces;
using Management.Application.Specializations.Commands.CommandTypes;
using AutoMapper;

namespace Management.Application.Specializations.Commands.CommandHandlers
{
    public class CreateSpecializationCommandHandler
        : IRequestHandler<CreateSpecializationCommand, Specialization>
    {

        private readonly ISpecializationRepository _specializationsRepository;
        private readonly IMapper _mapper;

        public CreateSpecializationCommandHandler(ISpecializationRepository specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
        }

        public async Task<Specialization> Handle(CreateSpecializationCommand request,
            CancellationToken cancellationToken)
        {

            var specialization = _mapper.Map<Specialization>(request);
            return await _specializationsRepository.CreateSpecialization(specialization, cancellationToken);
        }
    }
}
