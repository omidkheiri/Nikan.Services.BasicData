using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Nikan.Services.BasicData.Core.CompanyAggregate;

namespace Nikan.Services.BasicData.Infrastructure.Data.Config;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
  public void Configure(EntityTypeBuilder<Company> builder)
  {
    builder.ToTable("company");
    builder.HasKey(company => company.Id);
    builder.UseXminAsConcurrencyToken();

    builder.Property(company => company.Title).IsRequired();
    builder.Property(company => company.Phone).IsRequired();
    builder.Property(company => company.EmailAddress).IsRequired();
    builder.Property(company => company.PostalAddress);
    builder.Property(company => company.DateCreated);
    builder.Property(company => company.DateModified);
    builder.Property(company => company.CreatedBy);
    builder.HasIndex(company => company.Title).IsUnique();
    builder.HasIndex(company => company.Phone);
    builder.HasIndex(company => company.EmailAddress);

  }
}
