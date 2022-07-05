namespace Nikan.Services.BasicData.SharedKernel.Pagination;

public class ListParameters : QueryStringParameters
{
  public ListParameters()
  {
    OrderBy = "DateCreated";
  }
}
