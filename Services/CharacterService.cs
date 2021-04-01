using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnetrpg.Data;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnetrpg.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        private static List<CharacterDTO> characters = new List<CharacterDTO> {
            new CharacterDTO(),
            new CharacterDTO(){Name = "Sam", Id = 1}
        };

        private static CharacterDTO knight = new CharacterDTO();

        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            ServiceResponse<List<CharacterDTO>> serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            Character character = _mapper.Map<Character>(newCharacter);

            await _context.AddAsync(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<CharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDTO>>> GetAllCharacters()
        {
            ServiceResponse<List<CharacterDTO>> serviceResponse = new ServiceResponse<List<CharacterDTO>>();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDTO>> GetCharacterById(int id)
        {
            ServiceResponse<CharacterDTO> serviceResponse = new ServiceResponse<CharacterDTO>();
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<CharacterDTO>(character);
            return serviceResponse;
        }
    }
}