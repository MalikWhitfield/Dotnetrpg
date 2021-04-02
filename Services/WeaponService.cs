using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Dotnetrpg.Data;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Dotnetrpg.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        public WeaponService(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<CharacterDTO>> AddWeapon(AddWeaponDTO addWeaponDTO)
        {
            ServiceResponse<CharacterDTO> response = new ServiceResponse<CharacterDTO>();
            try
            {
                Character character = await _context.Characters.Include(c => c.CharacterSkills).FirstOrDefaultAsync(c => c.Id == addWeaponDTO.CharacterId && c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if (character == null)
                {
                    response.Success = false;
                    response.Message = "char not found";
                    return response;
                }
                Weapon weapon = new Weapon()
                {
                    Name = addWeaponDTO.Name,
                    Damage = addWeaponDTO.Damage,
                    Character = character
                };

                await _context.Weapons.AddAsync(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<CharacterDTO>(character);
                await _context.Weapons.AddAsync(weapon);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}