using Microsoft.EntityFrameworkCore;

namespace MailingListManagement.ApiService;

public class MailingListDbContext(DbContextOptions<MailingListDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(MailingListDbContext).Assembly);
    } 
}
