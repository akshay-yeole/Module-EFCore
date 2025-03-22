# Entity Framework Core (EF Core)

Entity Framework Core (EF Core) is a modern Object-Relational Mapper (ORM) for .NET applications, enabling developers to work with databases using .NET objects.

---

## 🚀 Implementation Approaches

### 1️⃣ Code-First  
Define your data model using C# classes, and EF Core generates the database schema for you.

### 2️⃣ Database-First  
Start with an existing database, and EF Core generates the corresponding data model.

---

## 📦 Required Packages

To get started with EF Core, add the following NuGet packages to your project:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
```

---

## 🛠️ Demo Application Steps

### 1. **Create a Console Application**  
Create a new console application and install the required packages mentioned above.

### 2. **📝 Create a Model**  
Define a class to represent your data model. For example:

```c#
public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailId { get; set; }
}
```

### 3. **⚙️ Configure the Database Context**  
Set up a `DbContext` class to manage database operations:

```c#
public class BookStoreContext : DbContext
{
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
```

### 4. **🔍 Query the Database**  
Perform CRUD operations in your `Program.cs` file. Below is an example implementation:

```c#
class Program
{
    private static readonly BookStoreContext context = new();

    static void CheckDatabaseConnection()
    {
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Database is created");
        }
        else
        {
            Console.WriteLine("Database already exists");
        }
    }

    static void Menu()
    {
        Console.WriteLine("1. Add Author");
        Console.WriteLine("2. Get Authors");
        Console.WriteLine("3. Delete Author");
        Console.WriteLine("4. Update Author");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }

    static void GetAuthors()
    {
        var authors = context.Authors.ToList();
        if (!authors.Any())
        {
            Console.WriteLine("No authors found");
            return;
        }

        Console.WriteLine("Authors:");
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.Id}\t {author.FirstName}\t {author.LastName}\t {author.EmailId}");
        }
    }

    static void AddAuthor(Author author)
    {
        context.Authors.Add(author);
        context.SaveChanges();
        Console.WriteLine("Author added successfully.");
    }

    static void DeleteAuthor(int id)
    {
        var author = context.Authors.Find(id);
        if (author != null)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
            Console.WriteLine("Author deleted successfully.");
        }
        else
        {
            Console.WriteLine("Author not found.");
        }
    }

    static void UpdateAuthor(int id, string firstName, string lastName, string emailId)
    {
        var author = context.Authors.Find(id);
        if (author != null)
        {
            author.FirstName = firstName;
            author.LastName = lastName;
            author.EmailId = emailId;
            context.SaveChanges();
            Console.WriteLine("Author updated successfully.");
        }
        else
        {
            Console.WriteLine("Author not found.");
        }
    }

    static void Main(string[] args)
    {
        CheckDatabaseConnection();

        while (true)
        {
            Menu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Author FirstName: ");
                    var firstName = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Author LastName: ");
                    var lastName = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter Author EmailId: ");
                    var emailId = Console.ReadLine() ?? string.Empty;
                    AddAuthor(new Author { FirstName = firstName, LastName = lastName, EmailId = emailId });
                    break;
                case "2":
                    GetAuthors();
                    break;
                case "3":
                    Console.Write("Enter Author Id to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        DeleteAuthor(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id.");
                    }
                    break;
                case "4":
                    Console.Write("Enter Author Id to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Enter Author FirstName: ");
                        var updateFirstName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter Author LastName: ");
                        var updateLastName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter Author EmailId: ");
                        var updateEmailId = Console.ReadLine() ?? string.Empty;
                        UpdateAuthor(updateId, updateFirstName, updateLastName, updateEmailId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.Write("Do you want to continue? (y/n): ");
            if (Console.ReadKey().KeyChar != 'y')
            {
                Console.WriteLine();
                break;
            }
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
```

---

## Using EF Migrations

### Add Migration  
Run the following command to create a migration:

```bash
Add-Migration 'InitialMigration'
```

### Generate Script  
Generate a SQL script for the migration:

```bash
Script-Migration
```

📖 For more details, visit the [official EF Core documentation](https://learn.microsoft.com/en-us/ef/core/).
