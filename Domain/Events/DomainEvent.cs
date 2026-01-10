namespace Domain.Events
{
    public abstract record DomainEvent
    {
        public Guid EventId { get; init; }
        public DateTime OccuredAt { get; set; }

        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
            OccuredAt = DateTime.UtcNow;
        }
    }
}
