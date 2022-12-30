using GroupApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Race> Races { get; set; }
		public DbSet<Club> Clubs { get; set; }	
		public DbSet<Address> Adresses { get; set; }

	}
}
