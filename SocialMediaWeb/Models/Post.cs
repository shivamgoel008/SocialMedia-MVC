using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SocialMediaWeb.Models
{
    public class Post
    {
        [Key] public int Id { get; set; }

        [Required] public int userId { get; set; }
        [Required] public string postImage { get; set; }
        [Required] public string postTitle { get; set; }
        [Required] public string postBio { get; set; }
        [Required] public DateOnly postDate { get; set; } = new DateOnly();

    }
}
