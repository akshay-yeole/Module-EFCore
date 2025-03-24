using Dummy_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dummy_EFCore.DataContext
{
    public class BookStoreContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) =>
            {
                return category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information;
            }).AddConsole();
        });

        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BookStoreData;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
