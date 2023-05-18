using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Име на жанр")]
        public string? GenreName { get; set; }

        public ICollection<BookGenres>? BookGenresId { get; set; }
    }
}
