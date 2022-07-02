namespace Nikan.Services.CrmProfiles.WebApi.V1.ApiModels;

public class CompanyDto : CreateCompanyDto
{
  public CompanyDto(Guid? id, string title) : base(title)
  {
    Title = title;
  }

  public string Title { get; set; }
}

public abstract class CreateCompanyDto
{
  protected CreateCompanyDto(string title)
  {
    Title = title;
  }

  public string Title { get; set; }
}
