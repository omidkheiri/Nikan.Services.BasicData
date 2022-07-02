using Nikan.Services.CrmProfiles.SharedKernel;

namespace Nikan.Services.CrmProfiles.Core.ProjectAggregate.Events
{
  public class ToDoItemCompletedEvent : DomainEventBase
  {
    public ToDoItem CompletedItem { get; set; }

    public ToDoItemCompletedEvent(ToDoItem completedItem)
    {
      CompletedItem = completedItem;
    }
  }
}