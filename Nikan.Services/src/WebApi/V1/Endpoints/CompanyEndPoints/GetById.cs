using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;


namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class GetById : EndpointBaseAsync.WithRequest<GetCompanyByIdRequest>
  .WithActionResult<GetCompanyByIdResponse>
{

  private readonly IMapper mapper;
  private readonly IRepository<Company> _repository;

  public GetById(IMapper mapper, IRepository<Company> repository)
  {
    this.mapper = mapper;
    _repository = repository;
  }

  [HttpGet(GetCompanyByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Company",
    Description = "Gets a single Company by Id",
    OperationId = "Company.GetById",
    Tags = new[] { "CompaniesEndPoint" })
  ]
  public override async Task<ActionResult<GetCompanyByIdResponse>> HandleAsync([FromRoute] GetCompanyByIdRequest request,
    CancellationToken cancellationToken = new CancellationToken())
  {

    var entity = await _repository.GetByIdAsync(request.CompanyId); // TODO: pass cancellation token
    if (entity == null) return NotFound();

    var res = mapper.Map<GetCompanyByIdResponse>(entity);
    return Ok(res);



  }
}
