using ApiOneOne.Data.Dto;
using ApiOneOne.Model;
using AutoMapper;

namespace ApiOneOne.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<CreateCharacterDto, Character>();
        CreateMap<Character, ReadCharacterDto>();
        CreateMap<UpdateCharacterDto, Character>();
    }
}
