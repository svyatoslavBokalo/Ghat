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
    public class Tag
    {
        public long Id { get; set; }
        public string? TagName {  get; set; }
        public string? Description { get; set; }

        public ICollection<Chat>? Chats { get; set; }
    }
}
