using Microsoft.EntityFrameworkCore;

namespace NobleApi.Models
{
    public class NoblerContext : DbContext
    {
        public NoblerContext(DbContextOptions<NoblerContext> options)
            : base(options)
        {
        }

        public DbSet<Nobler> Noblers { get; set; }
    }
}