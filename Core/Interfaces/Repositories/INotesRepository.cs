using Core.Entities;

namespace Core.Interfaces;

public interface INotesRepository
{
    Task<bool> IsNoteExist(int id);
    Task<IEnumerable<Note>> GetAllNotes();
    Task<IEnumerable<Note>> GetNotesByNameOrDescription(string name);
    Task Create(Note note);
    Task<Note> GetNoteById(int id);

    Task Update(Note note);
    Task DeleteNote(int id);
}