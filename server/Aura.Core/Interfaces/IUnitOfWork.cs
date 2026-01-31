using Aura.Core.Interfaces;

namespace Aura.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICandidateRepository Candidates { get; }
    Task<int> CompleteAsync();
}
