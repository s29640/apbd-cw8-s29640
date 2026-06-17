using System.ComponentModel.DataAnnotations;

namespace APBD_cw8_s29640.ViewModels
{
    public class CreateBookViewModel
    {
        public string? Title { get; set; }

        public string? Isbn { get; set; }

        [Required(ErrorMessage = "Published year is required.")]
        public int? PublishedYear { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public int? AuthorId { get; set; }
    }
}
