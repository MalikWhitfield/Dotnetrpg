using System.Threading.Tasks;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<CharacterDTO>> AddCharacterSkill(AddCharacterSkillDTO newCharacterSkill);
    }
}