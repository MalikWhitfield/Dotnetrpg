using System.Collections.Generic;
using System.Linq;
using Dotnetrpg.Models;

namespace Dotnetrpg.Services
{
    public class CharacterService : ICharacterService
    {

      private static List<Character> characters = new List<Character> {
            new Character(),
            new Character(){Name = "Sam", Id = 1}
        };

        private static Character knight = new Character();

        List<Character> ICharacterService.AddCharacter(Character newCharacter)
        {
             characters.Add(newCharacter);
            return characters;
        }

        List<Character> ICharacterService.GetAllCharacters()
        {
            return characters;
        }

        Character ICharacterService.GetCharacterById(int id)
        {
           return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}