namespace Nikan.Services.BasicData.SharedKernel.Pagination;

public interface ISortHelper<T>
{
  IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
}
