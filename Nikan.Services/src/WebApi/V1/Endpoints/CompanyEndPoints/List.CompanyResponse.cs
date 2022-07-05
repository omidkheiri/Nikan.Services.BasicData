using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Pagination;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class ListCompanyResponse
{
  public PagedList<Company> Companies { get; set; }
}
