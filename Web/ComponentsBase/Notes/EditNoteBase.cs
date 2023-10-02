using System.Reflection.Metadata;
using Core.Entities;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class EditNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork _unitOfWork { get; set; }
    [Parameter]
    public int Id { get; set; }
    public Note Note;
    
    protected override async Task OnInitializedAsync()
    {
        Note = await _unitOfWork.NotesRepository.GetNoteById(Id);
        await base.OnInitializedAsync();
    }

    public async Task Update()
    {
        await _unitOfWork.NotesRepository.Update(Note);
    }
}