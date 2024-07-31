using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ldis_Team_Project.ConfigurationModel
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.Messages);

            builder
                .HasMany(x => x.Chats)
                .WithMany(x => x.Messages);

            builder
                .HasMany(x => x.Reactions)
                .WithMany(x => x.Messages);

            builder
                .HasOne(x => x.MessageType)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.MessageTypeId)
                .IsRequired();

            builder
                .HasOne(x => x.ForwardedFrom)
                .WithMany(x => x.ForwardedMessages)
                .HasForeignKey(x => x.ForwardedFromId)
                .IsRequired(false);
        }
    }
}
