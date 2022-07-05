using Ardalis.Specification;

namespace Nikan.Services.BasicData.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
