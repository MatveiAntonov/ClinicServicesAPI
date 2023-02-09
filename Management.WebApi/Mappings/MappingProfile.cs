using AutoMapper;
using Management.WebApi.Models;
using Management.Domain.Entities;
using Management.Application.Services.Commands.CommandTypes;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using Management.Application.Specializations.Commands.CommandTypes;

namespace Management.WebApi.Mappings; 
public class MappingProfile : Profile {
    public MappingProfile()
    {
        CreateMap<Service, ServiceDto>()
            .ForMember(dest => dest.ServiceCategoryName, opt => opt.MapFrom(src => src.ServiceCategory.ServiceCategoryName))
            .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization.SpecializationName));
        CreateMap<CreateServiceCommand, Service>();
        CreateMap<UpdateServiceCommand, Service>();

        CreateMap<ServiceCategory, ServiceCategoryDto>();
        CreateMap<CreateServiceCategoryCommand, ServiceCategory>();
        CreateMap<UpdateServiceCategoryCommand, ServiceCategory>();

        CreateMap<Specialization, SpecializationDto>();
        CreateMap<CreateSpecializationCommand, Specialization>();
        CreateMap<UpdateSpecializationCommand, Specialization>();
    }
}
