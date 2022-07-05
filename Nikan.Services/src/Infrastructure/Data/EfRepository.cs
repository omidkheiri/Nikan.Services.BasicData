using System.Linq.Expressions;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Nikan.Services.BasicData.SharedKernel.Pagination;

namespace Nikan.Services.BasicData.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>,
  IRepository<T> where T : class, IAggregateRoot
{
  private readonly AppDbContext _appDbContext;
  private readonly ISortHelper<Company> _sortHelper;
  public EfRepository(AppDbContext appDbContext) : base(appDbContext)
  {
    _appDbContext = appDbContext;
    _sortHelper = new SortHelper<Company>();
  }


  public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
  {
    return _appDbContext.Set<T>()
      .Where(expression)
      .AsNoTracking();
  }
}
