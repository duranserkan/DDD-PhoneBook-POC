using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;
using SharedKernel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.DbContext
{
	public class PhoneBookDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private readonly IPublishEndpoint _publishEndpoint;

		public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options, IPublishEndpoint publishEndpoint) : base(options)
		{
			_publishEndpoint = publishEndpoint;
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			var change = await base.SaveChangesAsync(cancellationToken);
			await PublishDomainEvents();

			return change;
		}
		
		private async Task PublishDomainEvents()
		{
			var domainEventEntities = ChangeTracker.Entries<Entity>()
				.Select(entityEntry => entityEntry.Entity)
				.Where(entity => entity.Events.Any())
				.SelectMany(entity => entity.Events)
				.Select(domainEvent => _publishEndpoint.Publish(domainEvent));

			await Task.WhenAll(domainEventEntities);
		}
	}
}
