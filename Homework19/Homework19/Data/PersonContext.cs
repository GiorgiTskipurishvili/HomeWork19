using Homework19.Domain;
using Microsoft.EntityFrameworkCore;

namespace Homework19.Data
{
	public class PersonContext : DbContext
	{

		public DbSet<Person> Persons { get; set; }
		public DbSet<Address> Addresss { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Server=."); //Server Name 
		//}
		public PersonContext(DbContextOptions options) : base(options)
		{

		}
		
	}
}
