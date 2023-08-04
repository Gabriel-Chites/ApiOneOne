using System.ComponentModel.DataAnnotations;

namespace ApiOneOne.Data.Dto;

public class CreateCharacterDto
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public int AnimeId { get; set; }
}
