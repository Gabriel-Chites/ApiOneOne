using System.ComponentModel.DataAnnotations;

namespace ApiOneOne.Data.Dto;

public class CreateAnimeDto
{
    [Required]
    [StringLength(50, ErrorMessage = "O campo de nome só aceita até 50 caracteres")]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int ReleaseYear { get; set; }
}
