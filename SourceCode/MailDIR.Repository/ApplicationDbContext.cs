using MailDIR.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace MailDIR.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
                
        public DbSet<User> Users { get; set; }
        public DbSet<MailItem> MailItems { get; set; }
        public DbSet<MailDetail> MailDetails { get; set; }
        public DbSet<MailDetailsColMap> MailDetailsColMaps { get; set; }
    }
}