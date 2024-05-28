using Frontpoint.Core.Entities.IndividualAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frontpoint.Infrastructure.Data.Config;

public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
{
    public void Configure(EntityTypeBuilder<Individual> builder)
    {
        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Prefix)
            .HasMaxLength(25);

        builder.Property(p => p.FirstName)
            .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.MiddleName)
           .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH);

        builder.Property(p => p.LastName)
            .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.DateOfBirth)
           .IsRequired();

        builder.Property(p => p.TelephoneNumber)
           .HasMaxLength(25)
           .IsRequired();

        builder.Property(p => p.AddressLine1)
           .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH)
           .IsRequired();

        builder.Property(p => p.AddressLine2)
           .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH);

        builder.Property(p => p.City)
           .HasMaxLength(50)
           .IsRequired();

        builder.Property(p => p.State)
           .HasMaxLength(50)
           .IsRequired();

        builder.Property(p => p.Zip)
           .HasMaxLength(15)
           .IsRequired();

        builder.Property(p => p.Country)
          .HasMaxLength(50)
          .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(p => p.LastUpdatedBy)
            .HasMaxLength(SchemaConstants.DEFAULT_NAME_LENGTH);
    }
}