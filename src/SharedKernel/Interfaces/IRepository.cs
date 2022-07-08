using System.Linq.Expressions;
using Ardalis.Specification;
using Nikan.Services.BasicData.SharedKernel.Pagination;

namespace Nikan.Services.BasicData.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
  IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}

