using Microsoft.AspNetCore.Mvc;
using Nikan.Services.CrmProfiles.Core.AccountAggregate;
using Nikan.Services.CrmProfiles.SharedKernel.Interfaces;
using Nikan.Services.CrmProfiles.WebApi.V1.ApiModels;

namespace Nikan.Services.CrmProfiles.WebApi.V1.Controller;

/// <summary>
///   A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building
///   APIs
///   https://github.com/ardalis/ApiEndpoints
/// </summary>
[Route("/BasicData")]
public class CompnyController : BaseApiController
{
  private readonly IRepository<Company> _repository;

  public CompnyController(IRepository<Company> repository)
  {
    _repository = repository;
  }


  [HttpGet]
  public async Task<IActionResult> List()
  {
    var dataOwnerDTOs = (await _repository.ListAsync())
      .Select(dataowner => new CompanyDto
      (
        dataowner.Id,
        dataowner.Title
      ))
      .ToList();

    return Ok(dataOwnerDTOs);
  }
}
