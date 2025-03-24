## Ways to Create Relationships

EF Core provides three ways to define relationships:

1. **Conventions**  
    Relationships are automatically inferred based on property names and types. For example:

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

    > **Note:** Conventions are the simplest way to define relationships, but they may not cover all scenarios.

2. **Data Annotations**  
    Use attributes to explicitly define relationships. For example:

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

    > **Tip:** Data Annotations are useful for simple configurations but may become cumbersome for complex relationships.

3. **Fluent API**  
    Configure relationships explicitly in the `OnModelCreating` method. For example:

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

    > **Best Practice:** Use Fluent API for advanced configurations and when you need full control over the model.

### Choosing the Right Approach

Each approach has its use cases, and you can choose the one that best fits your project requirements:

- Use **Conventions** for quick and simple setups.
- Use **Data Annotations** for explicit configurations when working with smaller models.
- Use **Fluent API** for complex relationships or when overriding conventions.

> **Reminder:** You can combine these approaches, but Fluent API configurations will always override conventions and data annotations.
