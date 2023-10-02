using Core.Entities;
using Core.Interfaces.Data;
using Microsoft.AspNetCore.Components;

namespace Web.ComponentsBase;

public class CreateNoteBase : ComponentBase
{
    [Inject]
    private IUnitOfWork _unitOfWork { get; set; }
    private readonly NavigationManager _navManager;
    public Note Note = new Note();

    public CreateNoteBase()
    {
        
    }
    public CreateNoteBase(IUnitOfWork unitOfWork, NavigationManager navManager)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Create()
    {
        Note.CreationTime = DateTime.Now;
        await _unitOfWork.NotesRepository.Create(Note);
        _navManager.NavigateTo("/");
    }

}