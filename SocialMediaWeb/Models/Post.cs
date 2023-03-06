using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SocialMediaWeb.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required] public User userId { get; set; }
        public string postImage { get; set; }
        [Required] public string postDescription { get; set; }

        [Required] public DateTime postCreationDate { get; set; } = DateTime.Now;

    }
}
