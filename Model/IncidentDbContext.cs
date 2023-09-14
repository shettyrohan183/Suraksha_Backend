using Microsoft.EntityFrameworkCore;

namespace Final_youtube.Model
{
    public class IncidentDbContext:DbContext
    {
        public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<MediaAttachment> MediaAttachments { get; set; }
        
    }
}
