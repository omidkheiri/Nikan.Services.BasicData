using System.ComponentModel.DataAnnotations;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

public class CreateCompanyRequest
{
  public const string Route = "/Companies";

  [Required] public string? Title { get; set; }
  [Required] public string? Phone { get; set; }
  [Required] public string? EmailAddress { get; set; }
  public string? PostalAddress { get; set; }

}
