using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Наслов")]
        public string Title { get; set; }

        [Display(Name = "Година на издавање")]
        public int? ReleaseDate { get; set; }

        [Display(Name = "Број на страници")]
        public int? NumberOfPages { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Опис")]
        public string? Description { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Издавачка куќа")]
        public string? PublishingHouse { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Насловна")]
        public string? FrontPage { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Линк")]
        public string? DownloadUrl { get; set; }

        public int? AuthorId { get; set; }
        [Display(Name = "Автор")]
        public Author? Author { get; set; }
        public object Genre { get; internal set; }
    }
}
