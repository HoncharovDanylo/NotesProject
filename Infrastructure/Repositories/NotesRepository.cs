using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class NotesRepository : INotesRepository
{
    private readonly DataBaseContext _dbContext;

    public NotesRepository(DataBaseContext dataBaseContext)
    {
        _dbContext = dataBaseContext;
    }

    public async Task<bool> IsNoteExist(int id)
    {
        return await _dbContext.Notes.AnyAsync(note => note.Id == id);
    }

    public async Task<IEnumerable<Note>> GetAllNotes()
    {
        return  await _dbContext.Notes.AsNoTracking().ToListAsync();
    }

    public async  Task<IEnumerable<Note>> GetNotesByNameOrDescription(string name)
    {
        return await _dbContext.Notes.AsNoTracking().Where(note => note.Title.ToLower().Contains(name.ToLower())|| note.Description.ToLower().Contains(name.ToLower())).ToListAsync();
    }
    public async Task<Note> GetNoteById(int id)
    {
        return await _dbContext.Notes.AsNoTracking().FirstOrDefaultAsync(note => note.Id == id);
    }

    public async Task Create(Note note)
    {
        _dbContext.Notes.Add(note);
        await _dbContext.SaveChangesAsync();
    }

    

    public async Task Update(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteNote(int id)
    {
         var Note = await _dbContext.Notes.FirstAsync(note => note.Id == id);
        _dbContext.Notes.Remove(Note);
        await _dbContext.SaveChangesAsync();

    }
}