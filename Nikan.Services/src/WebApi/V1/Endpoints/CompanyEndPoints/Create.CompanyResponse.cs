namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class CreateCompanyResponse
{
  public CreateCompanyResponse(Guid id, 
    string title, 
    string phone,
    string emailAddress,
    string postalAddress, 
    DateTimeOffset dateCreated,
    DateTimeOffset dateModified,
    Guid createdBy)
  {
    Id = id;
    Title = title;
    Phone = phone;
    EmailAddress = emailAddress;
    PostalAddress = postalAddress;

   DateCreated= dateCreated;
   DateModified= dateModified;




    CreatedBy = createdBy;
  }
  public Guid Id { get; }
  public string Title { get; }
  public string Phone { get; }
  public string EmailAddress { get; }
  public string PostalAddress { get; }

  public Guid CreatedBy { get; }

  public DateTimeOffset DateCreated { get; private set; }
  public DateTimeOffset DateModified { get; private set; }

}
