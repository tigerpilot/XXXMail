using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class XxxDbContext : DbContext
    {
       public XxxDbContext(DbContextOptions<XxxDbContext> options) : base(options){}

       public DbSet<Mail> Mails { get; set; }
    }
}