using Ardalis.GuardClauses;
using Nikan.Services.BasicData.SharedKernel;
using Nikan.Services.BasicData.SharedKernel.Interfaces;

namespace Nikan.Services.BasicData.Core.CompanyAggregate;

public class Company : EntityBase, IAggregateRoot
{
  private Company()
  {
    Id = Guid.NewGuid();
    DateCreated = DateTimeOffset.UtcNow;
    DateModified = DateCreated;
  }

  public Company(string? title, string? phone, string? emailAddress, string? postalAddress,
    Guid createdBy) : this()
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
    EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    PostalAddress = postalAddress;
    CreatedBy = createdBy;

  }




  public string Title { get; private set; } = "";
  public string Phone { get; private set; } = "";
  public string EmailAddress { get; private set; } = "";
  public string? PostalAddress { get; private set; } = "";
  public DateTimeOffset DateCreated { get; private set; }
  public DateTimeOffset DateModified { get; private set; }
  public Guid CreatedBy { get; private set; }

  public void UpdateCompanyAsync(string? title, string? phone, string? emailAddress, string? postalAddress,
    Guid createdBy)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
    EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    PostalAddress = postalAddress;
    DateModified = DateTimeOffset.UtcNow;
    CreatedBy = createdBy;
  }
}
