using System.Collections.Generic;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);

    }
}