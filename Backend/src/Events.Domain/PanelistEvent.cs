namespace Events.Domain
{
    public class PanelistEvent
    {
        public int PanelistId { get; set; }
        public Panelist Panelist { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}