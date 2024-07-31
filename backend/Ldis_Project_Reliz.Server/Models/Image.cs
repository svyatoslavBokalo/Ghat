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
    //[Index(nameof(Id), nameof(CodeImg), IsUnique = true)]
    public class Image
    {
        public long Id { get; set; }
        public string? CodeImg {  get; set; }
        public string? Link {  get; set; }

        public ICollection<Chat>? Chats { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
