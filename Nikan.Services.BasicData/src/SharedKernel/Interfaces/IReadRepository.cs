using Ardalis.Specification;

namespace Nikan.Services.CrmProfiles.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
