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
        [Required, StringLength(50, MinimumLength = 4)]
        public string Theme { get; set; }
        [Required, Range(10, 120000)]
        public int NumPeople { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png|jfif)$")]
        public string UrlImage { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<SocialMediaDto> SocialMedias { get; set; }
        public IEnumerable<PanelistDto> Panelists { get; set; }
    }
}