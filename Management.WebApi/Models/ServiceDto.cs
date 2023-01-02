namespace Management.WebApi.Models;
public class ServiceDto {
    public int ServiceId { get; set; }
    public int ServiceCategoryId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public decimal ServicePrice { get; set; }
    public int SpecializationId { get; set; }
    public string ServiceCategoryName { get; set; } = string.Empty;
    public string SpecializationName { get; set; } = string.Empty;
}
