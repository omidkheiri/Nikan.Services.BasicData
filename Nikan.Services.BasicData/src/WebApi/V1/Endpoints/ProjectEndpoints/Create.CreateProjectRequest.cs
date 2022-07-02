using System.ComponentModel.DataAnnotations;

namespace Nikan.Services.CrmProfiles.WebApi.Endpoints.ProjectEndpoints
{
  public class CreateProjectRequest
  {
    public const string Route = "/Projects";

    [Required]
    public string? Name { get; set; }
  }
}
