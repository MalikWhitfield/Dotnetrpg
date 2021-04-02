using System.Threading.Tasks;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public interface IWeaponService
    {
        Task<ServiceResponse<CharacterDTO>> AddWeapon(AddWeaponDTO addWeaponDTO);
    }
}