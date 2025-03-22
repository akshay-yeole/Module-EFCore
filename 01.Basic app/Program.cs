using Module_EFcore;
using Microsoft.EntityFrameworkCore;

class Program
{
    private static BookStoreContext context = new();

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
        Console.WriteLine("3. Exit");
        Console.WriteLine("Enter your choice:");
    }

    static void GetAuthors()
    {
        var authors = context.Authors.ToList();
        if (authors.Count == 0)
        {
            Console.WriteLine("No authors found");
            return;
        }
        else
        {
            Console.WriteLine("Authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.Id}\t {author.FirstName}\t {author.LastName}\t {author.EmailId}" );
            }
        }
    }

    static void AddAuthor(Author author)
    {
        context.Authors.Add(author);
        context.SaveChanges();
    }



    static void Main(string[] args)
    {
        var isContinue = 'y';

        CheckDatabaseConnection();

        do
        {
            Menu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Author FirstName:");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Enter Author LastName:");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Enter Author EmailId:");
                    var emailId = Console.ReadLine();
                    AddAuthor(new Author { FirstName = firstName, LastName = lastName, EmailId = emailId });
                    break;
                case "2":
                    GetAuthors();
                    break;
                case "3":
                    isContinue = 'n';
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (isContinue != 'n')
            {
                Console.WriteLine("Do you want to continue ? (y/n) :: ");
                isContinue = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

        } while (isContinue == 'y');

        Console.WriteLine("Press any key to exit..");
        Console.ReadLine();
    }
}
