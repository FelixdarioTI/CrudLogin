using Microsoft.EntityFrameworkCore;
using mvc_f.Models;
namespace mvc_f.NovaPasta1
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            :base(options)
        {
           
        }
        public DbSet<ClassUser> ClassUser { get; set; }
    }
}
