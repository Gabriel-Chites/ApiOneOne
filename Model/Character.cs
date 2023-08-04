using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ApiOneOne.Model;

//Id(int)
//Nome(string)
//Descrição(string, opcional)
//AnimeId(int)
//Anime(Anime)
public class Character
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public int AnimeId { get; set; }

    public virtual Anime Anime { get; set; }
}
