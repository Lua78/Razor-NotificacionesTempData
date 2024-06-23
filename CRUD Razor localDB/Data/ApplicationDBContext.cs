using CRUD_Razor_localDB.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor_localDB.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
