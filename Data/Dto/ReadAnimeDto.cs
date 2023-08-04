using System.ComponentModel.DataAnnotations;

namespace ApiOneOne.Data.Dto;

public class ReadAnimeDto
{

    public string Name { get; set; }

    public string Description { get; set; }

    public int ReleaseYear { get; set; }
}
