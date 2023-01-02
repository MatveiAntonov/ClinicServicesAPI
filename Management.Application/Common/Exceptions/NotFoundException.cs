namespace Management.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Name, object Key)
            : base($"Entity \"{Name}\" ({Key}) not found.") { }
    }
}
