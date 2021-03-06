using System;
using System.Collections.Generic;

namespace Dotnetrpg.Models
{
    public class Character
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
        public List<CharacterSkill> CharacterSkills { get; set; }
        public Weapon Weapon { get; set; }

    }
}