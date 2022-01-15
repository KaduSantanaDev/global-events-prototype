using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Interfaces
{
    public interface IEventProtocols
    {       
        // Events
        Task<Event[]> GetEventsByThemeAsync(string theme, bool includePanelist = false);
        Task<Event[]> GetEventsAsync(bool includePanelist = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includePanelist = false);
    }
}