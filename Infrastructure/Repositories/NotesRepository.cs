using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly DataBaseContext _dbContext;

    public NotesRepository(DataBaseContext dataBaseContext)
    {
        _dbContext = dataBaseContext;
    }
    
}