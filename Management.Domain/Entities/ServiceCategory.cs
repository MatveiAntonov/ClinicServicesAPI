using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities {
    public class ServiceCategory {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; } = string.Empty;
        public DateTime? TimeSlotSize { get; set; }
        public ICollection<Service>? Services { get; set; }

    }
}
