using System.Threading.Tasks;
using Events.Domain;

namespace Events.Persistence.Interfaces
{
    public interface IGeneralProtocols
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        
        Task<bool> SaveChangesAsync();
        
    }
}