using System.ComponentModel.DataAnnotations;

namespace Dummy_EFCore.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }

        //Navigation Property
        public Author Author { get; set; }
    }
}
