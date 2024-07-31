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
    //[Index(nameof(Id), nameof(TypeVisible), IsUnique = true)]
    public class Visible
    {
        public long Id {  get; set; }
        public string? TypeVisible {  get; set; }
        public string? Description {  get; set; }

        public ICollection<Chat>? Chats { get; set; }
    }
}
