namespace Events
{
    public class ServiceCreated
    {
        public int Id { get; set; }
        public string ServiceCategoryName { get; set; } = String.Empty;
        public string ServiceName { get; set; }
        public double? ServicePrice { get; set; }
        public string SpecializationName { get; set; }
        public DateTime? TimeSlotSize { get; set; }
    }
}