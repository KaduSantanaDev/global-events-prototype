namespace Events.Domain
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? PanelistId { get; set; }
        public Panelist Panelist { get; set; }
    }
}