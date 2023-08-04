using System.ComponentModel.DataAnnotations;

namespace ApiOneOne.Data.Dto;

public class UpdateCharacterDto
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public int AnimeId { get; set; }
}
