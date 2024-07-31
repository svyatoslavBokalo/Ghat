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
    //[Index(nameof(Id), nameof(Link), IsUnique = true)]
    public class Chat
    {
        public long Id { get; set; }
        public string? NameChat {  get; set; }
        //[ForeignKey("Genre")]
        public long? GenreId {  get; set; }
        //[ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
        public string? Description { get; set;}
        //[ForeignKey("Visible")]
        public long? VisibleId { get; set; }
        [ForeignKey("VisibleId")]
        public Visible? Visible { get; set; }
        public DateTime? CreatDate { get; set; }
        public int? CountUsers { get; set; }
        public int? CurrentCountUsers { get; set; }
        public string? Link {  get; set; }
        public bool AutoDeletingUser { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        //[ForeignKey("Avatar")]
        public long? AvatarId { get; set; }
        //[ForeignKey("AvatarId")]
        public Image? Avatar { get; set; }
        public ICollection<Message>? Messages { get; set; } = new List<Message>();
        public ICollection<User>? Users { get; set; } = new List<User>();
        [Required]
        public int Actual {  get; set; } //для того чи такий чат існує, якщо actual=0 то такий чат видалений, якщо actual=1 то такий чат існує
    }
}
