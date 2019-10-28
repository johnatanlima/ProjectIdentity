using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using new1.Models;

namespace new1.Data
{
    public class RegistroDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Usuario> Usuarios {get; set;}
        
        public RegistroDbContext(DbContextOptions<RegistroDbContext> options)
            : base(options)
        {
        }
    }
}
