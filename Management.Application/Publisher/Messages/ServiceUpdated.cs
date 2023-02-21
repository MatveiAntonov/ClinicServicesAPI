namespace Events
{
    public class ServiceUpdated
    {
        public int Id { get; set; }
        public string ServiceCategoryName { get; set; } = String.Empty;
        public string ServiceName { get; set; } = String.Empty;
        public double? ServicePrice { get; set; }
        public string SpecializationName { get; set; } = String.Empty;
        public DateTime? TimeSlotSize { get; set; }
    }
}
