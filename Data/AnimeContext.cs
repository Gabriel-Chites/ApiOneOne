using ApiOneOne.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiOneOne.Data;

public class AnimeContext: DbContext
{

    public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
    {
        
    }

    public DbSet<Anime> Animes { get; set; }

    public DbSet<Character> Characters { get; set; }
}
