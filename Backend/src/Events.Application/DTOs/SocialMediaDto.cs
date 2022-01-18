using Events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Application.DTOs
{
    public class SocialMediaDto
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
