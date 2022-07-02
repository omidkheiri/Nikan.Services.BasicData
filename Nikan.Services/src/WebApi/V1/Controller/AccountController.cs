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
[Route("/Company/{CompanyId}")]
public class AccountController : BaseApiController
{
  private readonly IRepository<Account> _repository;

  public AccountController(IRepository<Account> repository)
  {
    _repository = repository;
  }


  [HttpGet]
  public async Task<IActionResult> List()
  {
    var dataOwnerDTOs = (await _repository.ListAsync())
      .Select(dataowner => new DataOwnerDto
      (
        dataowner.Id,
        dataowner.Title
      ))
      .ToList();

    return Ok(dataOwnerDTOs);
  }
}
