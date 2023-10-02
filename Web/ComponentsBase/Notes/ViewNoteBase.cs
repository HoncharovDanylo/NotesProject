using Core.Entities;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class ViewNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork? UnitOfWork { get; set; }
    [Parameter]
    public int Id { get; set; }

    protected Note Note { get; private set; } = new Note();
    protected override async Task OnInitializedAsync()
    {
        Note = await UnitOfWork.NotesRepository.GetNoteById(Id);
        await base.OnInitializedAsync();
    }
}