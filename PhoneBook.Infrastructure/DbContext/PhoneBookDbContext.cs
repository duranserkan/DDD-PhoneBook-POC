using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel;
using SharedKernel.Interfaces;

namespace PhoneBook.Infrastructure.DbContext
{
	public class PhoneBookDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options) { }

		public DbSet<Person> People { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await PublishDomainEvents();
			return await base.SaveChangesAsync(cancellationToken);
		}


		private async Task PublishDomainEvents()
		{
			var domainEventEntities = ChangeTracker.Entries<Entity>()
				.Select(po => po.Entity)
				.Where(po => po.Events.Any())
				.ToArray();

			foreach (var entity in domainEventEntities)
			{
				//todo:publish domain events;
			}
		}
	}
}
