using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.PersonAggregate;

namespace PhoneBook.Infrastructure.DbContext
{
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasKey(person => person.Id);
			builder.Property(person => person.Name).HasMaxLength(64).IsRequired();
			builder.Property(person => person.Surname).HasMaxLength(64).IsRequired();
			builder.Property(person => person.CompanyName);
			builder.Property(person => person.PhoneId);
			builder.Property(person => person.EmailId);
			builder.Property(person => person.LocationId);
		}
	}
}
