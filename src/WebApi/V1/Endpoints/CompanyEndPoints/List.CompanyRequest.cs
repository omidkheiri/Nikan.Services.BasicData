using Nikan.Services.BasicData.SharedKernel.Pagination;


namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class ListCompanyRequest : ListParameters
{
  public const string Route = "/Companies";

  public string SearchTerm { get; set; }

}
