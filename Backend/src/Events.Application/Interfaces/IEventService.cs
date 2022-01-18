using System.Threading.Tasks;
using Events.Application.DTOs;

namespace Events.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> AddEvents(EventDto model);
        Task<EventDto> UpdateEvent(int eventId, EventDto model);
        Task<bool> DeleteEvent(int eventId);
        
        Task<EventDto[]> GetEventsByThemeAsync(string theme, bool includePanelist = false);
        Task<EventDto[]> GetEventsAsync(bool includePanelist = false);
        Task<EventDto> GetEventByIdAsync(int eventId, bool includePanelist = false);
    }
}