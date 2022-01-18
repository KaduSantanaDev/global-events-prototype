using AutoMapper;
using Events.Application.DTOs;
using Events.Domain;

namespace Events.Application.Helpers
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Panelist, PanelistDto>().ReverseMap();
        }
    }
}
