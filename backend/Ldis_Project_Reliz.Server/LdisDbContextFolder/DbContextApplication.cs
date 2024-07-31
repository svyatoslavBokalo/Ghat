using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Team_Project.ConfigurationModel;
using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ldis_Project_Reliz.Server.LdisDbContext
{
    public class DbContextApplication : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visible> Visibles { get; set; }
      
        public DbContextApplication(DbContextOptions<DbContextApplication> options) :  base(options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var FileConfiguration = new ConfigurationBuilder().AddUserSecrets<DbContextApplication>().Build();
            //string ConnectionString = FileConfiguration.GetConnectionString("DataBaseConnect");
            //string connectionString = config.GetConnectionString("DefaultConnection");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Задайте шлях до поточного каталогу, де знаходиться ваш конфігураційний файл.
                .AddJsonFile("appsettings.json") // Вказати ім'я вашого конфігураційного файлу.
                .Build();
            string connectionString = configuration.GetConnectionString("DataBaseConnect");
            optionsBuilder.UseSqlite(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguraation());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
        }

    }
}
