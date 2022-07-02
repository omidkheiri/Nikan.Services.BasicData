﻿using Ardalis.Specification.EntityFrameworkCore;
using Nikan.Services.CrmProfiles.SharedKernel.Interfaces;

namespace Nikan.Services.CrmProfiles.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
