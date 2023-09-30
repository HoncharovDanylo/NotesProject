using Core.Entities;

namespace Core.Interfaces;

public interface INotesRepository
{
    IEnumerable<Note> GetAllNotes();
    IEnumerable<Note> GetNotesByNameOrDescription(string name);
    void Create(Note note);
    Note GetNoteById(int id);

    void Update(Note note);
}