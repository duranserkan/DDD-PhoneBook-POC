using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;

namespace PhoneBook.Infrastructure.DbContext
{
	public class PhoneBookDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
