using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SocialMediaWeb.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int postId { get; set; }
        [Required]
        public int userId { get; set; }
        [DisplayName("Upload File")] public string postImage { get; set; }

        [NotMapped][DisplayName("Upload File")] public IFormFile imageFile { get; set; }
        [Required] public string postDescription { get; set; }

        [Required] public DateTime postCreationDate { get; set; } = DateTime.Now;

    }
}
