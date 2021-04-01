using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;

        private static List<CharacterDTO> characters = new List<CharacterDTO> {
            new CharacterDTO(),
            new CharacterDTO(){Name = "Sam", Id = 1}
        };

        private static CharacterDTO knight = new CharacterDTO();

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            ServiceResponse<List<CharacterDTO>> serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            characters.Add(_mapper.Map<CharacterDTO>(newCharacter));
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> GetAllCharacters()
        {
            ServiceResponse<List<CharacterDTO>> serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDTO>> GetCharacterById(int id)
        {
            ServiceResponse<CharacterDTO> serviceResponse = new ServiceResponse<CharacterDTO>();
            serviceResponse.Data = _mapper.Map<CharacterDTO>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }
    }
}