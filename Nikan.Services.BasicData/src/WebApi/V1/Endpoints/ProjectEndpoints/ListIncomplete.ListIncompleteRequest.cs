using Microsoft.AspNetCore.Mvc;

namespace Nikan.Services.CrmProfiles.WebApi.Endpoints.ProjectEndpoints
{
  public class ListIncompleteRequest
  {
    [FromRoute]
    public int ProjectId { get; set; }
    [FromQuery]
    public string? SearchString { get; set; }
  }
}