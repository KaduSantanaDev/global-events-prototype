using Events.Domain;
using System.Collections.Generic;

namespace Events.Application.DTOs
{
    public class PanelistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string Phone { get; set; }
        public int Email { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<PanelistDto> Panelists { get; set; }
    }
}
