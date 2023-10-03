using System.Reflection.Metadata;
using Core.Entities;
using Core.Interfaces.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class EditNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork? UnitOfWork { get; set; }
    [Inject]
    private NavigationManager NavManager { get; set; }  
    [Inject]
    private NotFoundListener NotFoundListener { get; set; }
    
    [Parameter]
    public int Id { get; set; }
    public Note? Note;
    
    protected override async Task OnInitializedAsync()
    {
        Note = await UnitOfWork.NotesRepository.GetNoteById(Id);
        if(Note==null)
            NotFoundListener.NotifyNotFound();
        else
        await base.OnInitializedAsync();
    }

    public async Task Update()
    {
        await UnitOfWork.NotesRepository.Update(Note);
        NavManager.NavigateTo("/");
    }
}