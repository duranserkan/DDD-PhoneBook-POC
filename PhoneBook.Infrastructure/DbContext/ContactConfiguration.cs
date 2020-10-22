using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.ContactAggregate;

namespace PhoneBook.Infrastructure.DbContext
{
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.HasKey(contact => contact.Id);
			builder.Property(contact => contact.Content).HasMaxLength(256).IsRequired();
			builder.Property(contact => contact.ContactType);
			builder.Ignore(x => x.Events);
		}
	}
}
