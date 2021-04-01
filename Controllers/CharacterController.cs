using System.Collections.Generic;
using System.Linq;
using Dotnetrpg.Models;
using Dotnetrpg.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dotnetrpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService){
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(){
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpPost]
        public IActionResult Create(Character character){
            return Ok(_characterService.AddCharacter(character));
        }
    }
}