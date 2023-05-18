using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class UserBooks
    {
        public int Id { get; set; }

        [StringLength(450, MinimumLength = 3)]
        [Required]
        [Display(Name = "Корисници")]
        public string? AppUser { get; set; }

        public int? BookId { get; set; }
        [Display(Name = "Book")]
        public Book? Book { get; set; }
    }
}
