using Management.Domain.Entities;

namespace Management.WebApi.Models;
    public class SpecializationDto {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; } = String.Empty;
    }
