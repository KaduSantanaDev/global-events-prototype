using Events.Domain;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistence.Context
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
            
        }
        public DbSet<Event> Events  { get; set; }
        public DbSet<Batch> Batches  { get; set; }
        public DbSet<Panelist> Panelists  { get; set; }
        public DbSet<PanelistEvent> PanelistsEvents  { get; set; }
        public DbSet<SocialMedia> SocialMedias  { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<PanelistEvent>().HasKey(PE => new {PE.EventId, PE.PanelistId});
            
            modelBuilder.Entity<Event>()
            .HasMany(e => e.SocialMedias)
            .WithOne(sm => sm.Event)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Event>()
            .HasMany(e => e.Batches)
            .WithOne(sm => sm.Event)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Panelist>()
            .HasMany(e => e.SocialMedias)
            .WithOne(sm => sm.Panelist)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}