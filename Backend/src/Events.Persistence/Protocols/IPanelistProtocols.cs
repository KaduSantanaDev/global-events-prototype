using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Protocols
{
    public interface IPanelistProtocols
    {
        Task<Panelist[]> GetPanelistsByNameAsync(string name, bool includeEvents);
        Task<Panelist[]> GetPanelistsAsync(bool includeEvents);
        Task<Panelist> GetPanelistByIdAsync(int PanelistId, bool includeEvents);
        
    }
}