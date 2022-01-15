using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Protocols
{
    public interface IEventProtocols
    {       
        // Events
        Task<Event[]> GetEventsByThemeAsync(string theme, bool includePanelist);
        Task<Event[]> GetEventsAsync(bool includePanelist);
        Task<Event> GetEventByIdAsync(int eventId, bool includePanelist);
    }
}