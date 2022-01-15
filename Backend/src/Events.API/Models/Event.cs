namespace Events.API.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Local { get; set; }
        public string DateEvent { get; set; }
        public string Theme { get; set; }
        public int NumPeople { get; set; }
        public string Batch { get; set; }
        public string UrlImage { get; set; }
    }
}