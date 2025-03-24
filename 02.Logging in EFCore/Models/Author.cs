using System.ComponentModel.DataAnnotations;

namespace Dummy_EFCore.Models
{
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
        [StringLength(50),MinLength(10)]
        public string Location { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; }

    }
}
