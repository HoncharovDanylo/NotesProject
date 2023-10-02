using Core.Entities;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class ViewNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork _unitOfWork { get; set; }
    [Parameter]
    public int id { get; set; }

    public Note Note { get; set; } = new Note();
    protected override async Task OnInitializedAsync()
    {
        Note = await _unitOfWork.NotesRepository.GetNoteById(id);
        await base.OnInitializedAsync();
    }
}