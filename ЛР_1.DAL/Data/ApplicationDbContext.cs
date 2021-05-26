using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ЛР_1.DAL.Entities;

namespace ЛР_1.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }
        public DbSet<Course> Students { get; set; }
        public DbSet<Groups> Groups { get; set; }
    }
}
