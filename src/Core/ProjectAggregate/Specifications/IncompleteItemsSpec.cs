using Ardalis.Specification;

namespace Nikan.Services.CrmProfiles.Core.ProjectAggregate.Specifications
{
  public class IncompleteItemsSpec : Specification<ToDoItem>
  {
    public IncompleteItemsSpec()
    {
      Query.Where(item => !item.IsDone);
    }
  }
}