using System.Threading.Tasks;
using Events.Persistence.Context;
using Events.Persistence.Interfaces;

namespace Events.Persistence
{
    public class GeneralPersistence : IGeneralProtocols
    {
        private readonly EventContext _context;

        public GeneralPersistence(EventContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync())  > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}