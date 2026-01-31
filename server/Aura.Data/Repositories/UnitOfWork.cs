using Aura.Core.Interfaces;
using Aura.Data.Context;

namespace Aura.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuraDbContext _context;

    public UnitOfWork(AuraDbContext context)
    {
        _context = context;
        Candidates = new CandidateRepository(_context);
    }

    public ICandidateRepository Candidates { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
