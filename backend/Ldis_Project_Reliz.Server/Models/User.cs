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
    public class User
    {
        public long Id { get; set; }
        public string? UserName {  get; set; }
        [Required]
        public bool? IsRegidtred {  get; set; }
        public string? IpAdress {  get; set; }
        public string? Enail {  get; set; }
        public string? Password {  get; set; }
        public int? Phonenumber {  get; set; }
        //[ForeignKey("Avatar")]
        public long? AvatarId { get; set; }
        //[ForeignKey("AvatarId")]
        public Image? Avatar { get; set; }
        public string? Status {  get; set; }
        public DateTime? LastSeen { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public ICollection<Chat>? Chats { get; set; }
        public ICollection<Message>? ForwardedMessages {  get; set; }
        public ICollection<Message>? Messages {  get; set; }
        [Required]
        public int Actual {  get; set; }//для чи такий юзер існує, якщо actual=0 то такий юзер видалений, якщо actual=1 то існує
    }
}
