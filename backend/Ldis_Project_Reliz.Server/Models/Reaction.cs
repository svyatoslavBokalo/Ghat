using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ldis_Team_Project.Models
{
    //[Index(nameof(Id), IsUnique = true)]
    public class Reaction
    {
        public long Id { get; set; }
        public string? NameReaction { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
