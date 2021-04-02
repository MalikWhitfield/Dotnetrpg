using System;

namespace Dotnetrpg.Models
{
    public class ITrackable
    {
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

    }
}