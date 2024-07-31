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
    public class Message
    {
        public long Id { get; set; }
        public ICollection<Chat>? Chats { get; set; }
        public ICollection<User>? Users { get; set; }
        public string? Content { get; set; }
        public DateTime? Timestamp { get; set; }
        public bool? IsRead { get; set; }
        //[ForeignKey("MessageType")]
        public long? MessageTypeId { get; set; }
        //[ForeignKey("MessageTypeId")]
        public MessageType? MessageType { get; set; }
        public bool? edited { get; set; }
        public ICollection<Reaction>? Reactions { get; set; }
        //[ForeignKey("ForwardedFrom")]
        public long? ForwardedFromId { get; set; }
        //[ForeignKey("ForwardedFromId")]
        public User? ForwardedFrom { get; set; }
        public bool? deletedBySender { get; set; }
        public bool? deletedByReceiver { get; set; }

    }
}
