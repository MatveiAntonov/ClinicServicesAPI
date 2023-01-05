using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities {
    public class Specialization {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; } = String.Empty;
        public ICollection<Service> Services { get; set; }
    }
}
