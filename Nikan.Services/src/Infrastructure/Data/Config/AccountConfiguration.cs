using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nikan.Services.CrmProfiles.Core.AccountAggregate;

namespace Nikan.Services.CrmProfiles.Infrastructure.Data.Config;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {
    builder.ToTable("account");
    builder.HasKey(account => account.Id);
    builder.Property(account => account.Title).IsRequired();
    builder.Property(account => account.Phone).IsRequired();
    builder.Property(account => account.EmailAddress).IsRequired();
    builder.Property(account => account.PostalAddress);
    builder.Property(account => account.DateIssued);
    builder.Property(account => account.CompanyId);
  }
}
