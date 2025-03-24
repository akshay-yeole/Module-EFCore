# Entity Framework Core (EF Core)

Entity Framework Core (EF Core) is a modern Object-Relational Mapper (ORM) for .NET applications, enabling developers to work with databases using .NET objects. It simplifies database interactions by abstracting SQL queries and allowing developers to use LINQ and C# objects.

---

## 📖 Table of Contents

1. [Introduction to EF Core](#introduction-to-ef-core)
2. [Implementation Approaches](#implementation-approaches)
3. [Required Packages](#required-packages)
4. [Step-by-Step Guide](#step-by-step-guide)
    - [Create a Console Application](#1-create-a-console-application)
    - [Create a Model](#2-create-a-model)
    - [Configure the Database Context](#3-configure-the-database-context)
    - [Query the Database](#4-query-the-database)
5. [Using EF Migrations](#using-ef-migrations)
6. [Data Annotations](#data-annotations)
7. [Relationships in EF Core](#relationships-in-ef-core)
8. [Logging in EF Core](#logging-in-ef-core)
9. [Ways to Create Relationships](#ways-to-create-relationships)
10. [Further Reading](#further-reading)

---

## Introduction to EF Core

Entity Framework Core (EF Core) is a lightweight, extensible, and cross-platform ORM for .NET. It allows developers to interact with databases using strongly-typed C# objects instead of raw SQL queries.

---

## Implementation Approaches

### 1️⃣ Code-First  
Define your data model using C# classes, and EF Core generates the database schema for you. This approach is ideal for greenfield projects where the database structure is not predefined.

### 2️⃣ Database-First  
Start with an existing database, and EF Core generates the corresponding data model. This approach is suitable for legacy systems or when working with an existing database.

---

## 📦 Required Packages

To get started with EF Core, add the following NuGet packages to your project:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
```

These packages provide the necessary tools and database provider for SQL Server.

---

## 🛠️ Step-by-Step Guide

### 1. **Create a Console Application**  
Create a new console application and install the required packages mentioned above.

### 2. **Create a Model**  
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

This class represents the `Author` table in the database.

### 3. **Configure the Database Context**  
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

The `DbContext` class acts as a bridge between your application and the database.

### 4. **Query the Database**  
Perform CRUD operations in your `Program.cs` file. Below is an example implementation:

- **Check Database Connection**: Ensures the database is created.
- **Menu**: Provides options for CRUD operations.
- **CRUD Methods**: Add, retrieve, update, and delete authors.

---

## Using EF Migrations

### Add Migration  
Run the following command to create a migration:

```bash
Add-Migration 'InitialMigration'
```

### Update Database  
Run the following command to apply a migration:

```bash
Update-Database
```

### Remove Migration  
Run the following command to remove a migration:

```bash
Remove-Migration
```

### Generate Script  
Generate a SQL script for the migration:

```bash
Script-Migration
```

Migrations help manage database schema changes over time.

---

## Data Annotations

Data annotations are used to add constraints to the tables. Below is an example for the `Author` table:

```c#
public class Author
{
     public int Id { get; set; }

     [Required]
     [StringLength(50)]
     public string FirstName { get; set; } = string.Empty;

     [Required]
     [StringLength(50)]
     public string LastName { get; set; } = string.Empty;

     [Required]
     [StringLength(50)]
     public string EmailId { get; set; } = string.Empty;

     [Required]
     [StringLength(50), MinLength(10)]
     public string Location { get; set; } = string.Empty;
}
```

These annotations enforce validation rules at the database level.

---

## Relationships in EF Core

EF Core supports various types of relationships:

1. **One-to-Many Relationship**  
    Example: An `Author` can have multiple `Books`.

2. **Many-to-One Relationship**  
    Example: Multiple `Books` belong to one `Author`.

3. **Many-to-Many Relationship**  
    Example: `Authors` and `Books` can have a many-to-many relationship.

### One-to-Many Relationship Example

```c#
public class Author
{
     public int Id { get; set; }

     [Required]
     [StringLength(50)]
     public string FirstName { get; set; } = string.Empty;

     [Required]
     [StringLength(50)]
     public string LastName { get; set; } = string.Empty;

     [Required]
     [StringLength(50)]
     public string EmailId { get; set; } = string.Empty;

     public IEnumerable<Book> Books { get; set; }
}
```

```c#
public class Book
{
     public int Id { get; set; }

     [Required]
     public string Title { get; set; }

     [Required]
     public int Price { get; set; }

     // Navigation Property
     public Author Author { get; set; }
}
```

After defining the relationship, add a migration and run the `Update-Database` command.

---

## Logging in EF Core

To enable logging, install the `Microsoft.Extensions.Logging.Console` package. Update the `BookStoreContext` as follows:

```c#
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

     public DbSet<Author> Authors { get; set; }
     public DbSet<Book> Books { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BookStoreData;Trusted_Connection=True;TrustServerCertificate=True;");
     }
}
```

This configuration logs database commands to the console for debugging purposes.

---

## Ways to Create Relationships

EF Core provides three ways to define relationships:

1. **Conventions**: Automatically inferred based on property names.

    Example:

    ```c#
    public class Author
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
         public int Id { get; set; }
         public string Title { get; set; }
         public int AuthorId { get; set; }
         public Author Author { get; set; }
    }
    ```

    In this example, EF Core automatically infers a one-to-many relationship between `Author` and `Book` based on the navigation properties.

2. **Data Annotations**: Use attributes to define relationships.

    Example:

    ```c#
    public class Author
    {
         public int Id { get; set; }
         public string Name { get; set; }

         [InverseProperty("Author")]
         public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
         public int Id { get; set; }
         public string Title { get; set; }

         [ForeignKey("Author")]
         public int AuthorId { get; set; }
         public Author Author { get; set; }
    }
    ```

    Here, `[InverseProperty]` and `[ForeignKey]` attributes explicitly define the relationship.

3. **Fluent API**: Configure relationships explicitly in the `OnModelCreating` method.

    Example:

    ```c#
    public class BookStoreContext : DbContext
    {
         public DbSet<Author> Authors { get; set; }
         public DbSet<Book> Books { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
              modelBuilder.Entity<Book>()
                    .HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId);
         }
    }
    ```

    The Fluent API provides a programmatic way to configure relationships, offering more control and flexibility.

---

## Further Reading

📖 For more details, visit the [official EF Core documentation](https://learn.microsoft.com/en-us/ef/core/).
