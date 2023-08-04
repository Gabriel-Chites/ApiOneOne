using ApiOneOne.Data.Dto;
using ApiOneOne.Model;
using AutoMapper;

namespace ApiOneOne.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<CreateAnimeDto, Anime>();
            CreateMap<Anime, ReadAnimeDto>();

        }
    }
}
