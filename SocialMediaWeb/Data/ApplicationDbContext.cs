

using Microsoft.EntityFrameworkCore;
using SocialMediaWeb.Models;
namespace SocialMediaWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
        }
        // categories is the table name
        // get is getter and set is setter
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
