using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class Delete : EndpointBaseAsync.WithRequest<DeleteCompanyByIdRequest>.WithActionResult<DeleteCompanyByIdResponse>
{
  private readonly IRepository<Company> _repository;


  public Delete(IRepository<Company> repository)
  {
    _repository = repository;
  }


  [HttpDelete(DeleteCompanyByIdRequest.Route)]
  [SwaggerOperation(Summary = "Delete a company", Description = "Delete a company record",
    OperationId = "Companies.Delete"
  , Tags = new[] { "CompaniesEndPoint" })]

  public override async Task<ActionResult<DeleteCompanyByIdResponse>> HandleAsync([FromRoute] DeleteCompanyByIdRequest request, CancellationToken cancellationToken = default)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.CompanyId, cancellationToken); // TODO: pass cancellation token
    if (aggregateToDelete == null) return NotFound();

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();

  }
}
