using System.ComponentModel.DataAnnotations;

namespace ApiOneOne.Data.Dto;

public class ReadCharacterDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int AnimeId { get; set; }
}
