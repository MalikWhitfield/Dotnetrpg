using System;
using System.Collections.Generic;
using Dotnetrpg.Models;

namespace Dotnetrpg.DTOs.Character
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
        public List<GetSkillDTO> Skills { get; set; }
    }
}