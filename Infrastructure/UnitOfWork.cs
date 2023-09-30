using Core.Interfaces;
using Core.Interfaces.Data;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _dataBaseContext;

    public UnitOfWork(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    
    public INotesRepository NotesRepository  => new NotesRepository(_dataBaseContext);

    public async Task<bool> Complete()
    {
        return await _dataBaseContext.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _dataBaseContext.ChangeTracker.HasChanges();
    }
    public void Dispose()
    {
     _dataBaseContext.Dispose();    
    }
}