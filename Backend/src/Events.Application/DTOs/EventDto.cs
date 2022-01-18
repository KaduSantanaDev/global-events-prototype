using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Events.Application.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DateEvent { get; set; }
        public string Theme { get; set; }
        public int NumPeople { get; set; }
        public string UrlImage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<SocialMediaDto> SocialMedias { get; set; }
        public IEnumerable<PanelistDto> Panelists { get; set; }
    }
}