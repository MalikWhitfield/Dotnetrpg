using System;
using System.Collections.Generic;

namespace Dotnetrpg.Models
{
    public class User : ITrackable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Character> Characters { get; set; }
    }
}