using System.Linq;
using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;
using Events.Persistence.Protocols;

namespace Events.Persistence
{
    public class PanelistPersistence : IPanelistProtocols
    {
        private readonly EventContext _context;
        
        public PanelistPersistence(EventContext context)
        {
            _context = context;
            
        }
        public async Task<Panelist> GetPanelistByIdAsync(int panelistId, bool includeEvents = false)
        {
            IQueryable<Panelist> query = _context.Panelists
            .Include(e => e.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                .Include(e => e.PanelistsEvents)
                .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id)
            .Where(p => p.Id == panelistId);            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Panelist[]> GetPanelistsAsync(bool includeEvents)
        {
            IQueryable<Panelist> query = _context.Panelists
            .Include(p => p.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                .Include(p => p.PanelistsEvents)
                .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id);
            
            return await query.ToArrayAsync();
        }
    

        public async Task<Panelist[]> GetPanelistsByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Panelist> query = _context.Panelists
            .Include(p => p.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                .Include(p => p.PanelistsEvents)
                .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id).Where(p => p.Name.ToLower().Contains(name.ToLower()));
            
            return await query.ToArrayAsync();
        }
    }
}