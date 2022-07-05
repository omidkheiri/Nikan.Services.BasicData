namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class GetCompanyByIdResponse
{



  public Guid Id { get; set; }
  public string? Title { get; set; }
  public string? Phone { get; set; }
  public string? EmailAddress { get; set; }
  public string? PostalAddress { get; set; }
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset DateModified { get; set; }
  public Guid CreatedBy { get; }
}
