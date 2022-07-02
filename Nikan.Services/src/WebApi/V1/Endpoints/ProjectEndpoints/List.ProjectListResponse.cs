
using System.Collections.Generic;

namespace Nikan.Services.CrmProfiles.WebApi.Endpoints.ProjectEndpoints
{
  public class ProjectListResponse
  {
    public List<ProjectRecord> Projects { get; set; } = new();
  }
}
