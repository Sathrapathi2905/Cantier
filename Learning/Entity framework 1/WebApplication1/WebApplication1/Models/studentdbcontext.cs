using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace WebApplication1.Models
{
    public class studentdbcontext : DbContext
    {
        public studentdbcontext(DbContextOptions<studentdbcontext> options) : base(options)
        { 
        }
            public DbSet <student> students { get;set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-URM2ERI;Initial Catalog=blackmirror;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False");
        }
    }
}



