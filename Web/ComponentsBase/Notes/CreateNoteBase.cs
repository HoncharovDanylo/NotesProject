using Core.Entities;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class CreateNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork? UnitOfWork { get; set; }
    [Inject]
    private NavigationManager? NavManager { get; set; }
    public Note Note = new Note();
    public async Task Create()
    {
        Note.CreationTime = DateTime.Now;
        await UnitOfWork.NotesRepository.Create(Note);
        NavManager.NavigateTo("/");
    }

}