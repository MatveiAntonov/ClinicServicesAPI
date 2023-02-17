namespace Management.Domain.Interfaces.Shared
{
    public interface ServiceCreated
    {
        public string ServiceCategoryName { get; set; }
        public string ServiceName { get; set; }
        public double? ServicePrice { get; set; }
        public string? SpecializationName { get; set; }
        public DateTime? TimeSlotSize { get; set; }
    }
}