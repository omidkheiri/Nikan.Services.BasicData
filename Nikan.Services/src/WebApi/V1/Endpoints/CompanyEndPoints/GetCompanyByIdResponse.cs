namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class GetCompanyByIdResponse
{
  public GetCompanyByIdResponse(Guid id, string title, string phone, string emailAddress, string postalAddress, DateTimeOffset dateIssued, Guid createdBy)
  {
    Id = id;
    Title = title;
    Phone = phone;
    EmailAddress = emailAddress;
    PostalAddress = postalAddress;
    DateIssued = dateIssued;
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
