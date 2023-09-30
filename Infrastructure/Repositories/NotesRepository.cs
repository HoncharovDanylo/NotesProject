using Core.Entities;
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

    public IEnumerable<Note> GetAllNotes()
    {
        return _dbContext.Notes.AsEnumerable();
    }

    public IEnumerable<Note> GetNotesByNameOrDescription(string name)
    {
        return _dbContext.Notes.Where(note => note.Title.ToLower().Contains(name.ToLower())|| note.Description.ToLower().Contains(name.ToLower()));
    }

    public void Create(Note note)
    {
        _dbContext.Notes.Add(note);
        _dbContext.SaveChanges();
    }
}