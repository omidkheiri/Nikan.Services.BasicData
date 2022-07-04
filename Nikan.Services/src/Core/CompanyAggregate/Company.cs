using Ardalis.GuardClauses;
using Nikan.Services.BasicData.SharedKernel;
using Nikan.Services.BasicData.SharedKernel.Interfaces;

namespace Nikan.Services.BasicData.Core.CompanyAggregate;

public class Company : EntityBase, IAggregateRoot
{
  private Company()
  {
    Id = Guid.NewGuid();
    DateIssued = DateTimeOffset.Now;
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
  public DateTimeOffset DateIssued { get; private set; }
  public Guid CreatedBy { get; private set; }
}
