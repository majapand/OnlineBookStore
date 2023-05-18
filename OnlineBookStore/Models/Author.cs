using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Име")]
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Презиме")]
        public string? LastName { get; set; }

        [Display(Name = "Датум на раѓање")]
        [DataType(DataType.Date)]

        public DateTime? BirthDate { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Националност")]
        public string? Nationality { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Пол")]
        public string? Gender { get; set; }

        [Display(Name = "Автор")]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
