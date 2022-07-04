using Ardalis.GuardClauses;
using Nikan.Services.BasicData.SharedKernel;
using Nikan.Services.BasicData.SharedKernel.Interfaces;

namespace Nikan.Services.BasicData.Core.AccountAggregate;

public class Company : EntityBase, IAggregateRoot
{
  private Company()
  {
    Id = Guid.NewGuid();
    DateIssued = DateTimeOffset.Now;
  }

  public Company(string title, string phone, string emailAddress, string postalAddress,
    Guid createdBy) : this()
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
    EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    PostalAddress = postalAddress;
    CreatedBy = createdBy;

  }


  public Guid Id { get; }

  public string Title { get; }
  public string Phone { get; }
  public string EmailAddress { get; }
  public string PostalAddress { get; }
  public DateTimeOffset DateIssued { get; }
  public Guid CreatedBy { get; }
}
