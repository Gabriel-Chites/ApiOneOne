using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ApiOneOne.Model;

//Id(int)
//Nome(string)
//Descrição(string)
//Ano de lançamento(int)
//Personagens(ICollection<Personagem>)
public class Anime
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "O campo de nome só aceita até 50 caracteres")]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }

    [Required]
    public int ReleaseYear { get; set; }

    [JsonIgnore]
    public virtual ICollection<Character> Characters { get; set; }

    public Anime()
    {
        Characters = new List<Character>();
    }
}
