using System.ComponentModel.DataAnnotations;

namespace Book_Library.Models.DTOs
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Range(1900, 2100, ErrorMessage = "Publication Year must be between 1900 and 2100.")]
        public int PublicationYear { get; set; }
    }
}
