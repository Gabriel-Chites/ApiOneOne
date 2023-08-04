using ApiOneOne.Data;
using ApiOneOne.Data.Dto;
using ApiOneOne.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiOneOne.Controllers;

[ApiController]
[Route("animes")]
public class AnimesController : ControllerBase
{
    private AnimeContext _context;
    private IMapper _mapper;

    public AnimesController(AnimeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateAnime([FromBody] CreateAnimeDto dto)
    {
        var anime = _mapper.Map<Anime>(dto);
        _context.Animes.Add(anime);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAnime), new { Id = anime.Id}, anime);
    }

    [HttpPost("{animeId}/personagens")]
    public IActionResult AddCharacterToAnime(int animeId, [FromBody] CreateCharacterDto characterDto)
    {
        var character = _mapper.Map<Character>(characterDto);

        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == animeId);

        if (anime == null) return NotFound();
   
        anime.Characters.Add(character);
        _context.Characters.Add(character);

        _context.SaveChanges();

        return Ok(character);
    }

    [HttpGet]
    public IActionResult GetAnimes()
    {
        return Ok(_mapper.Map<IList<ReadAnimeDto>>(_context.Animes.ToList()));
    }

    [HttpGet("{id}")]
    public IActionResult GetAnime(int id)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == id);

        if (anime is null) return NotFound();

        var animeDto = _mapper.Map<ReadAnimeDto>(anime);
        return Ok(animeDto);
    }

    [HttpGet("{animeId}/personagens")]
    public IActionResult GetCharacters(int animeId)
    {
        var anime = 
            _context.Animes.FirstOrDefault(anime => anime.Id == animeId);

        if (anime is null) return NotFound();

        return Ok(_mapper.Map<List<ReadCharacterDto>>(anime.Characters.ToList()));
    }

    [HttpGet("{animeId}/{characterId}")]
    public IActionResult GetCharacter(int animeId, int characterId)
    {
        var anime =
            _context.Animes.FirstOrDefault(anime => anime.Id == animeId);

        if (anime is null) return NotFound();

        var character =
            anime.Characters.FirstOrDefault(character => character.Id == characterId);

        if (character is null) return NotFound();

        return Ok(character);
    }

    [HttpPut("{animeId}")]
    public IActionResult UpdateAnime(int animeId, [FromBody] CreateAnimeDto animeDto)
    {
        var anime =
            _context.Animes.FirstOrDefault(anime => anime.Id == animeId);

        if (anime is null) return NotFound();

        _mapper.Map(anime, animeDto); 
        _context.SaveChanges();

        return Ok(animeDto);
    }

    [HttpPut("{animeId}/{characterId}")]
    public IActionResult UpdateCharacterFromAnime(int animeId, int characterId, [FromBody] UpdateCharacterDto characterDto)
    {
        var anime =
            _context.Animes.FirstOrDefault(anime => anime.Id == characterId);

        if (anime is null) return NotFound();

        var character = anime.Characters
            .FirstOrDefault(character => character.Id == characterId);

        if(character is null) return NotFound();

        _mapper.Map(characterDto, character);
        _context.SaveChanges();

        return Ok(characterDto);
    }

    [HttpDelete("{animeId}")]
    public IActionResult DeleteAnime(int animeId)
    {
        var anime = _context.Animes.FirstOrDefault(anime => anime.Id == animeId);

        if (anime is null) return NotFound();

        _context.Animes.Remove(anime);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{animeId}/{characterId}")]
    public IActionResult DeleteCharacterFromAnime(int animeId, int characterId)
    {
        var anime
            = _context.Animes.FirstOrDefault(anime => anime.Id == animeId);
        if (anime is null) return NotFound();

        var character =
            anime.Characters.FirstOrDefault(character => character.Id == characterId);
        if (character is null) return NotFound();

        anime.Characters.Remove(character);

        _context.SaveChanges();

        return NoContent();
    }
    //public int soma(int x, int y) => x + y;
}
