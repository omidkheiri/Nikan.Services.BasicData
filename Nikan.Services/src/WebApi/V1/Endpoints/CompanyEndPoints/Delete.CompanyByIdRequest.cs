namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class DeleteCompanyByIdRequest
{


  public const string Route = "/Companies/{CompanyId:guid}";
  public static string BuildRoute(Guid companyId) => Route.Replace("{CompanyId:guid}", companyId.ToString());

  public Guid CompanyId { get; set; }


}
