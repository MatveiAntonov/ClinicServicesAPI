using Management.Domain.Entities;

namespace Management.WebApi.Models;
public class ServiceCategoryDto 
{
    public int ServiceCategoryId { get; set; }
    public string ServiceCategoryName { get; set; } = string.Empty;
    public DateTime TimeSlotSize { get; set; }
}
