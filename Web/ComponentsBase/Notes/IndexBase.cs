using Core.Entities;
using Core.Enums;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class IndexBase : ComponentBase
{
    [Inject]
    private IUnitOfWork? UnitOfWork { get; set; }
    
    protected int NoteToDelete { get;set;}
    protected bool ShowDeletionWindow { get; set; }
    protected IEnumerable<Note> Notes = new List<Note>();
    protected string? SearchValue { get; set; }
    public NotesSortOrder SortOrder { get; set; } = NotesSortOrder.CreationTimeDesc;
 
    protected override async Task OnInitializedAsync()
    {
        Notes = await UnitOfWork.NotesRepository.GetAllNotes();
        
        await base.OnInitializedAsync();
    }

    public async Task GetNotes()
    {
        if (string.IsNullOrWhiteSpace(SearchValue))
            Notes = await UnitOfWork.NotesRepository.GetAllNotes();
        else
            Notes = await UnitOfWork.NotesRepository.GetNotesByNameOrDescription(SearchValue);
        OrderNotes();
    }

    public void OrderNotes()
    {
        switch (SortOrder)
        {
            case NotesSortOrder.TitleAsc:
                Notes = Notes.OrderBy(note => note.Title);
                break;
            case NotesSortOrder.TitleDesc:
                Notes = Notes.OrderByDescending(note => note.Title);
                break;
            case NotesSortOrder.CreationTimeAsc:
                Notes = Notes.OrderBy(note => note.CreationTime);
                break;
            case NotesSortOrder.CreationTimeDesc:
                Notes = Notes.OrderByDescending(note => note.CreationTime);
                break;
        }
    }

}