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
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CharacterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CharacterDTO>> AddCharacterSkill(AddCharacterSkillDTO newCharacterSkill)
        {
            ServiceResponse<CharacterDTO> response = new ServiceResponse<CharacterDTO>();
            try
            {
                Character character = await _context.Characters.Include(c => c.CharacterSkills).FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                    return response;
                }

                Skill skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);

                if (skill == null)
                {
                    response.Success = false;
                    response.Message = "Skill not found";
                    return response;
                }

                CharacterSkill characterSkill = new CharacterSkill()
                {
                    Character = character,
                    Skill = skill
                };

                await _context.CharacterSkills.AddAsync(characterSkill);
                await _context.SaveChangesAsync();

            }

            catch (Exception ex)
            {
                response.Success = false;
                // response.Message = ex.message;
            }

            throw new System.NotImplementedException();
        }
    }
}