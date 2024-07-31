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
    public class TagConfiguraation : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder
                .HasMany(x => x.Chats)
                .WithMany(x => x.Tags);
        }
    }
}
