using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Note
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? Title { get; set; }
    
    [Required]
    public DateTime CreationTime { get; set; }
    
    [Required]
    public string? Description { get; set; }
}