using Core.Entities;
using Core.Interfaces.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class ViewNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork? UnitOfWork { get; set; }
    [Inject]
    private NotFoundListener NotFoundListener { get; set; }
    [Parameter]
    public int Id { get; set; }

    protected Note Note { get; private set; } = new Note();
    protected override async Task OnInitializedAsync()
    {
        Note = await UnitOfWork.NotesRepository.GetNoteById(Id);
        if (Note == null)
            NotFoundListener.NotifyNotFound();
        await base.OnInitializedAsync();
    }
}