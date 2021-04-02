using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDTO>>> GetAllCharacters(int userId);
        Task<ServiceResponse<CharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<CharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);

    }
}