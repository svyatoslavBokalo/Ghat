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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(x => x.Messages)
                .WithMany(x => x.Users);

            builder
                .HasMany(x => x.Chats)
                .WithMany(x => x.Users);



            builder
                .HasOne(x => x.Avatar)
                .WithMany(x => x.Users).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.AvatarId)
                .IsRequired();

        }
    }
}
