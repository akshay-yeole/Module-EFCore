using Microsoft.EntityFrameworkCore;

namespace Module_EFcore
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
