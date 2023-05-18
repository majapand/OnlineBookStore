using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class BookGenres
    {
        public int Id { get; set; }

        public int? BookId { get; set; }
        [Display(Name = "Book")]
        public Book? Book { get; set; }

        public int? GenreId { get; set; }
        [Display(Name = "Genre")]
        public Genre? Genreid { get; set; }
    }
}
