using System.ComponentModel.DataAnnotations;

namespace SocialMediaWeb.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string userName { get; set; }
        [Required] public string userEmail { get; set; }
        [Required] [Range(8,100,ErrorMessage ="Minimum 8 Character Required")] public string  userPassword{ get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
