using System.Linq;
using System.Threading.Tasks;
using Events.Domain;
using Microsoft.EntityFrameworkCore;
using Events.Persistence.Interfaces;
using Events.Persistence.Context;

namespace Events.Persistence
{
    public class EventPersistence : IEventProtocols
    {
        private readonly EventContext _context;

        public EventPersistence(EventContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        
        public async Task<Event[]> GetEventsAsync(bool includePanelist = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);
            
            if (includePanelist)
            {
                query = query
                .Include(e => e.PanelistsEvents)
                .ThenInclude(pe => pe.Panelist);
            }
            
            query = query.OrderBy(e => e.Id);
            
            return await query.ToArrayAsync();
            
        }
        public async Task<Event> GetEventByIdAsync(int eventId, bool includePanelist = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);
            
            if (includePanelist)
            {
                query = query
                .Include(e => e.PanelistsEvents)
                .ThenInclude(pe => pe.Panelist);
            }
            
            query = query.OrderBy(e => e.Id)
            .Where(e => e.Id == eventId);
            
            return await query.FirstOrDefaultAsync();
        }


        public async Task<Event[]> GetEventsByThemeAsync(string theme, bool includePanelist = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);
            
            if (includePanelist)
            {
                query = query
                .Include(e => e.PanelistsEvents)
                .ThenInclude(pe => pe.Panelist);
            }
            
            query = query.OrderBy(e => e.Id)
            .Where(e => e.Theme
            .ToLower()
            .Contains(theme.ToLower()));
            
            return await query.ToArrayAsync();
        }

        public async Task<Panelist> GetPanelistByIdAsync(int panelistId, bool includeEvents)
        {
            IQueryable<Panelist> query = _context.Panelists
            .Include(p => p.SocialMedias);
            
            if (includeEvents)
            {
                query = query
                .Include(p => p.PanelistsEvents)
                .ThenInclude(pe => pe.Event);
            }
            
            query = query.OrderBy(p => p.Id)
            .Where(p => p.Id == panelistId);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Panelist[]> GetPanelistsAsync(bool includeEvents = false)
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