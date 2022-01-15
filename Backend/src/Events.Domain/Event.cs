using System;
using System.Collections.Generic;

namespace Events.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DateEvent { get; set; }
        public string Theme { get; set; }
        public int NumPeople { get; set; }
        public string UrlImage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<PanelistEvent> PanelistsEvents { get; set; }
    }
}