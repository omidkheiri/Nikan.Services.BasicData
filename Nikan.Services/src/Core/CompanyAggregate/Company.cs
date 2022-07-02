using Ardalis.GuardClauses;
using Nikan.Services.CrmProfiles.SharedKernel;
using Nikan.Services.CrmProfiles.SharedKernel.Interfaces;

namespace Nikan.Services.CrmProfiles.Core.AccountAggregate;

public class Company : EntityBase, IAggregateRoot
{
  private Company()
  {
    Id = Guid.NewGuid();
    DateIssued = DateTimeOffset.Now;
  }

  public Company(Guid companyId, string title, string phone, string emailAddress, string postalAddress,
    Guid createdBy) : this()
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Phone = Guard.Against.NullOrEmpty(title, nameof(title));
    EmailAddress = Guard.Against.NullOrEmpty(title, nameof(title));
    PostalAddress = postalAddress;
    CreatedBy = createdBy;
    CompanyId = companyId;
  }


  public Guid Id { get; }
  public Guid CompanyId { get; }
  public string Title { get; }
  public string Phone { get; }
  public string EmailAddress { get; }
  public string PostalAddress { get; }
  public DateTimeOffset DateIssued { get; }
  public Guid CreatedBy { get; }
}
