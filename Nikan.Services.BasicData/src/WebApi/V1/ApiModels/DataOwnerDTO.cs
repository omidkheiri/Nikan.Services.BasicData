namespace Nikan.Services.CrmProfiles.WebApi.V1.ApiModels;

public class DataOwnerDto : CreateDataOwnerDto
{
  public DataOwnerDto(Guid? id, string title) : base(title)
  {
    Title = title;
  }

  public string Title { get; set; }
}

public abstract class CreateDataOwnerDto
{
  protected CreateDataOwnerDto(string title)
  {
    Title = title;
  }

  public string Title { get; set; }
}
