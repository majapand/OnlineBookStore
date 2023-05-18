using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        [Display(Name = "Book")]
        public Book? Book { get; set; }

        [StringLength(450, MinimumLength = 3)]
        [Required]
        [Display(Name = "Корисници")]
        public string? AppUser { get; set; }


        [StringLength(500, MinimumLength = 3)]
        [Required]
        [Display(Name = "Коментар")]
        public string? Comment { get; set; }

        [Display(Name = "Рејтинг")]
        public int? Rating { get; set; }
    }
}
