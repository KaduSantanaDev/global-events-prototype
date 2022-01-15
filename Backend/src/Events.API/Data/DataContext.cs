using Events.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Events.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Event> Events  { get; set; }
    }
}