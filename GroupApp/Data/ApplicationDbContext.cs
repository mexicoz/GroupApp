using GroupApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Race> Races { get; set; }
		public DbSet<Club> Clubs { get; set; }	
		public DbSet<Adress> Adresses { get; set; }

	}
}
