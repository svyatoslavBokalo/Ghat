using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ldis_Team_Project.ConfigurationModel
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {

            builder
                .HasMany(x => x.Messages)
                .WithMany(x => x.Chats);

            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.Chats);

            builder
                .HasMany(x => x.Tags)
                .WithMany(x => x.Chats);

            builder
                .HasOne(el => el.Genre)
                .WithMany(el=>el.Chats).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(el => el.GenreId)
                .IsRequired();

            builder
                .HasOne(x => x.Visible)
                .WithMany(x => x.Chats).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.VisibleId)
                .IsRequired();

            builder
                .HasOne(x => x.Avatar)
                .WithMany(x => x.Chats).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.AvatarId)
                .IsRequired();

        }
    }
}
