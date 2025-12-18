using Microsoft.EntityFrameworkCore;

namespace azure_app_adonis.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
    public DbSet<Person> Persons { get; set; }
	}
}

