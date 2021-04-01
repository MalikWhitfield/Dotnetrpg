using AutoMapper;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;

namespace Dotnetrpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDTO>();
        }
    }
}