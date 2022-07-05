using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;


public class Create : EndpointBaseAsync.WithRequest<CreateCompanyRequest>.WithActionResult<CreateCompanyResponse>
{
  private readonly IMapper mapper;
  private readonly IRepository<Company> _repository;

  public Create(IMapper mapper, IRepository<Company> repository)
  {
    this.mapper = mapper;
    _repository = repository;
  }

  [HttpPost(CreateCompanyRequest.Route)]
  [SwaggerOperation(Summary = "Create a new company", Description = "Create a new company",
    OperationId = "Project.Create", Tags = new[] { "CompaniesEndPoint" })]
  public override async Task<ActionResult<CreateCompanyResponse>> HandleAsync(CreateCompanyRequest request, CancellationToken cancellationToken = default)
  {
    Guid creator = Guid.NewGuid();
    var newCompany = new Company(request.Title, request.Phone, request.EmailAddress, request.PostalAddress, creator);

    var createdItem = await _repository.AddAsync(newCompany);

    return Ok(mapper.Map<CreateCompanyResponse>(createdItem));


  }
}
