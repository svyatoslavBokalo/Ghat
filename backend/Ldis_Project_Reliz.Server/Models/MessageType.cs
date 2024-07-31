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
    //[Index(nameof(Id), nameof(TypeMessage), IsUnique = true)]
    public class MessageType
    {
        public long Id { get; set; }
        public string? TypeMessage {  get; set; }
        public string? Description {  get; set; }

        public ICollection<Message>? Messages { get; set; }   
    }
}
