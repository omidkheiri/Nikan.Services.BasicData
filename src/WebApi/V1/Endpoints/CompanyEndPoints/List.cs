using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Nikan.Services.BasicData.SharedKernel.Pagination;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;



public class List : EndpointBaseAsync.WithRequest<ListCompanyRequest>.WithResult<PagedList<Company>>
{
  private readonly IRepository<Company> _repository;
  private readonly SortHelper<Company> _sortHelper;
  public List(IRepository<Company> repository)
  {
    _repository = repository;
    _sortHelper = new SortHelper<Company>();
  }
  [HttpGet(ListCompanyRequest.Route)]
  [SwaggerOperation(Summary = "List companies", Description = "List companies record",
    OperationId = "Companies.List"
    , Tags = new[] { "CompaniesEndPoint" })]
  public override async Task<PagedList<Company>> HandleAsync([FromQuery] ListCompanyRequest request, CancellationToken cancellationToken = new CancellationToken())
  {

    var companies = _repository.FindByCondition(i => i.Title.ToLower().Contains(request.SearchTerm) ||
                                                   i.Phone.ToLower().Contains(request.SearchTerm) ||
                                                   i.EmailAddress.ToLower().Contains(request.SearchTerm));
    var sortedOwners = _sortHelper.ApplySort(companies, request.OrderBy);

    var list = PagedList<Company>.ToPagedList(sortedOwners,
      request.PageNumber,
      request.PageSize);
    var metadata = new
    {
      list.TotalCount,
      list.PageSize,
      list.CurrentPage,
      list.TotalPages,
      list.HasNext,
      list.HasPrevious
    };

    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));


    return list;

  }
}
