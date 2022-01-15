using System.Threading.Tasks;
using Events.Domain;

namespace Events.Application.Interfaces
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);
        
        Task<Event[]> GetEventsByThemeAsync(string theme, bool includePanelist = false);
        Task<Event[]> GetEventsAsync(bool includePanelist = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includePanelist = false);
    }
}