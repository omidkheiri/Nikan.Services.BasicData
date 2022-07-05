using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;


public class Update : EndpointBaseAsync
  .WithRequest<UpdateCompanyRequest>
  .WithActionResult<UpdateCompanyResponse>
{
  private readonly IRepository<Company> _repository;
  private readonly IMapper _mapper;

  public Update(IRepository<Company> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }




  [HttpPut(UpdateCompanyRequest.Route)]
  [SwaggerOperation(Summary = "Update a Company",
    Description = "Updates a company whit other data ",
    OperationId = "Company.Update",
    Tags = new[] { "CompaniesEndPoint" })]
  public override async Task<ActionResult<UpdateCompanyResponse>> HandleAsync(UpdateCompanyRequest request, CancellationToken cancellationToken = default)
  {
    if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Phone) || string.IsNullOrEmpty(request.EmailAddress))
    {

      return BadRequest();
    }

    var existingCompany = await _repository.GetByIdAsync(request.CompanyId, cancellationToken);
    if (existingCompany == null)
    {
      return NotFound();

    }

    existingCompany.UpdateCompanyAsync(request.Title, request.Phone, request.EmailAddress, request.PostalAddress, Guid.NewGuid());
    await _repository.UpdateAsync(existingCompany, cancellationToken = default);


    var response = _mapper.Map<UpdateCompanyResponse>(existingCompany);

    return Ok(response);


  }
}
