using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities {
    public class Service {
        public int ServiceId { get; set; }
        public int ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; } = new();
        public string ServiceName { get; set; } = string.Empty;
        public double? ServicePrice { get; set; }
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; } = new();
    }
}
