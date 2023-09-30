namespace Core.Interfaces.Data;

public interface IUnitOfWork : IDisposable
{ 
    INotesRepository NotesRepository { get;}
    Task<bool> Complete();
    bool HasChanges();
    void Dispose();
}