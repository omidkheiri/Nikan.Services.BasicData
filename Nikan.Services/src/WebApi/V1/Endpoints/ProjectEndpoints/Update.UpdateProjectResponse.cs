namespace Nikan.Services.CrmProfiles.WebApi.Endpoints.ProjectEndpoints
{
  public class UpdateProjectResponse
  {
    public UpdateProjectResponse(ProjectRecord project)
    {
      Project = project;
    }
    public ProjectRecord Project { get; set; }
  }
}