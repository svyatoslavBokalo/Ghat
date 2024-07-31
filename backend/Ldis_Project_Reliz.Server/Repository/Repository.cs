using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.LdisDbContext;
using Ldis_Project_Reliz.Server.Models.BusinesModel;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Project_Reliz.Server.Services.Realization;
using Ldis_Team_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ldis_Project_Reliz.Server.Repository
{
    public class RepositoryRealization : IRepository
    {
        DbContextApplication Context;
        ILoadUploadImageServerService LoadImage;
        IHttpContextAccessor ContextAccessor;
        public RepositoryRealization(DbContextApplication Context, ILoadUploadImageServerService LoadImage, IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
            this.Context = Context;
            this.LoadImage = LoadImage;
        }
        public async Task AddMessage(string Message, string GroupName, string UserName,string Email)
        {
            var Chat = await Context.Chats.Include(x => x.Visible).Include(x => x.Messages).FirstOrDefaultAsync(x => x.NameChat == GroupName);
            var User = await Context.Users.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Enail == Email);
            string TypeMessage = null;
            if (Chat.Visible.TypeVisible == "public")
            {
                TypeMessage = "public";
            }
            else if (Chat.Visible.TypeVisible == "private")
            {
                TypeMessage = "private";
            }
            var MessageTypeInstance = new MessageType()
            {
                Messages = new List<Message>(),
                TypeMessage = TypeMessage,
            };
            var MessageInstance = new Message
            {
                Chats = new List<Chat> (),
                Users = new List<User> (),
                Content = Message,
                Timestamp = DateTime.Now,
                IsRead = true,
                edited = false,
                Reactions = new List<Reaction>(),
                ForwardedFrom = User,
                ForwardedFromId = User.Id,
                deletedByReceiver = false,
                deletedBySender = false,
                MessageType = MessageTypeInstance
            };
            Chat.Messages.Add(MessageInstance);
            User.Messages.Add(MessageInstance);
            Context.AddRange(MessageInstance,MessageTypeInstance);
            Context.SaveChanges();
        }
        public string AddToGroup(string UserName, string GroupName, string Email,out bool sucssesfulAdded)
        {
            var Chat = Context.Chats.Include(x => x.Users).FirstOrDefault(x => x.NameChat == GroupName);
            int currentCountUsers = Chat.CurrentCountUsers.Value + 1;
            if (currentCountUsers > Chat.CountUsers)
            {
                sucssesfulAdded = false;
                return "Все места в группе заняты";
            }
            var User = Context.Users.Include(x => x.Chats).FirstOrDefault(x => x.UserName == UserName && Email == Email);
            Chat.CurrentCountUsers++;
            Chat.Users.Add(User);
            User.Chats.Add(Chat);
            Context.SaveChanges();
            sucssesfulAdded = true;
            return "";
        }
        public void CreateNewUser(string Email, string UserName, string Password, string ImageLink)
        {
            ContextAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.UserName,UserName);
            if (ImageLink == null)
            {
                ImageLink = "https://icons.veryicon.com/png/o/miscellaneous/rookie-official-icon-gallery/225-default-avatar.png";
            }
            Random rand = new Random();
             string CodeImg = Convert.ToString(rand.Next(100000));
             var ImageInstance = new Image()
             {
                Link = ImageLink,
                CodeImg = CodeImg,
                Chats = new List<Chat>(),
                Users = new List<User>()
             };
            var UserInstance = new User()
            {
                UserName = UserName,
                Password = Password,
                Avatar = ImageInstance,
                IsRegidtred = true,
                Actual = 1,
                Status = "Online",
                Enail = Email,
                ForwardedMessages = new List<Message>(),
                Messages = new List<Message>(),
                RegisteredAt = DateTime.Now
            };
            Context.AddRange(UserInstance,ImageInstance);
            Context.SaveChanges();
        }
        public void ExitFromGroup(string Email, string ChatName)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            var Chat = Context.Chats.FirstOrDefault(x => x.NameChat == ChatName);
            Chat.CurrentCountUsers--;
            User.Chats.Remove(Chat);
            Chat.Users.Remove(User);
            Context.SaveChanges();
        }
        public async Task<bool> FindUserForСheckExistence(string Email)
        {
            var options = new DbContextOptionsBuilder<DbContextApplication>()
                .UseSqlite("DataBaseConnect")
                .Options;
            //using(DbContextApplication db = new DbContextApplication(options))
            //{
            //    return await db.Users.AnyAsync(x => x.Enail == Email);
            //}
            using (Context = new DbContextApplication(options))
            {
                return await Context.Users.AnyAsync(x => x.Enail == Email);
            }
        }
        public User FindUserByEmailForDeletedTimer (string Email)
        {
            var User = Context.Users.Include(x => x.Chats).Include(x => x.Messages).FirstOrDefault(x => x.Enail == Email);
            return User;
        }
        public bool FindUserForСheckExistenceLogin(string Email, string Password)
        {
            var User = Context.Users.AsNoTracking().FirstOrDefault(x => x.Enail == Email && x.Password == Password);
            if (User == null)
                return false;
            else
                ContextAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.UserName,User.UserName);
                return true;
        }
        public bool FindUserForСheckExistenceRegistration(string Email, string Password)
        {
            var User = Context.Users.AsNoTracking().FirstOrDefault(x => x.Enail == Email || x.Password == Password);
            if (User == null)
                return false;
            else
                return true;
        }
        public void SetStatusConnected(string Email)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            User.Status = "Connected";
            Context.SaveChanges();
        }
        public void SetStatusDisconnected(string Email)
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == Email);
            User.Status = "Disconnected";
            Context.SaveChanges();
        }
        public void CreateNewGroup(string NameGroup,string Description,int CountUsers,bool AutoDeletingUser,string Genre,string Visible, IFormFile file )
        {
            var ImageInfo = LoadImage.LoadChatAvatar(file, NameGroup);
            string ImageCode = null, ImageLink = null;
            foreach (var item in ImageInfo)
            {
                if (item.Key == "ImageName")
                {
                    ImageCode = item.Value;
                }
                if (item.Key == "FullPathToFile")
                {
                    ImageLink = item.Value;
                }
            }
            var AvatarInstance = AddNewImage(ImageCode, ImageLink);
            var GenreInstance = new Genre
            {
                NameGenre = Genre,
                Chats = new List<Chat>()
            };
            var VisibleInstance = new Visible
            {
                TypeVisible = Visible,
                Chats = new List<Chat>()
            };
            var GroupInstance = new Chat
            {
                NameChat = NameGroup,
                Description = Description,
                CountUsers = CountUsers,
                AutoDeletingUser = AutoDeletingUser,
                Genre = GenreInstance,
                CreatDate = DateTime.Now,
                Messages = new List<Message>(),
                Users = new List<User>(),
                Visible = VisibleInstance,
                Avatar = AvatarInstance,
                AvatarId = AvatarInstance.Id,
                Tags = new List<Tag>()
            };
            Context.AddRange(GenreInstance, GroupInstance);
            Context.SaveChanges();
        }
        public List<Chat> FindChat(string NameChat)
        {
            var SuitableChatName = new List<string>();
            var SuitableChat = new List<Chat>();
            var TempCollectionChat = Context.Chats.AsNoTracking().ToList();
            foreach (var item in TempCollectionChat)
            {
                int distance = LevenshtainDistance.Calculate(NameChat.ToLower(),item.NameChat.ToLower());
                if (distance <= 2)
                {
                    SuitableChatName.Add(item.NameChat);
                }
                foreach (string name in SuitableChatName)
                {
                    var Chat = TempCollectionChat.FirstOrDefault(x => x.NameChat == name);
                    SuitableChat.Add(Chat);
                }
            }
            return SuitableChat;
        }
        public Image AddNewImage(string ImageCode,string LinkImage)
        {
            var ImageInstance = new Image
            {
                CodeImg = ImageCode,
                Chats = new List<Chat>(),
                Users = new List<User>(),
                Link = LinkImage
            };
            return ImageInstance;
        }
        public void UptadeUserAvatar(IFormFile file)
        {

            string UserName = ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.UserName];
            string Email = ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail];
            var User = Context.Users.Include(x => x.Avatar).FirstOrDefault(x => x.Enail == Email);
            var ImageInfo = LoadImage.LoadUserAvatar(file,UserName);
            string ImageCode = null, ImageLink = null;
            foreach (var item in ImageInfo)
            {
                if (item.Key == "ImageName")
                {
                    ImageCode = item.Value;
                }
                if (item.Key == "FullPathToFile")
                {
                    ImageLink = item.Value;
                }
            }
            var AvatarInstance = AddNewImage(ImageCode,ImageLink);
            User.Avatar = AvatarInstance;
            Context.SaveChanges();
        }
        public string ChangeUserName(string UserName)
        {
            var ExistUserName = Context.Users.AsNoTracking().FirstOrDefault(x => x.UserName == UserName);
            if (ExistUserName == null)
            {
                var User = Context.Users.FirstOrDefault(x => x.Enail == ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail]);
                User.UserName = UserName;
                Context.SaveChanges();
                return "Имя успешно изменено";
            }
            return "Данное имя уже занято";
        }
        public string ChangePassword(string Password)
        {
            var ExistPassword = Context.Users.AsNoTracking().FirstOrDefault(x => x.Password == Password);
            if (ExistPassword == null)
            {
                var User = Context.Users.FirstOrDefault(x => x.Enail == ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail]);
                User.Password = Password;
                Context.SaveChanges();
                return "Пароль успешно изменен";
            }
            return "Данный пароль уже занят";
        }
        public string DeleteAccount()
        {
            var User = Context.Users.FirstOrDefault(x => x.Enail == ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail]);
            if (User != null)
            {
                ContextAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail);
                ContextAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.UserName);
                Context.Remove(User);
                Context.SaveChanges();
                return "Аккаунт успешно удален";
            }
            return "Ошибка операции";
        }
        public Chat RandomChat()
        {
            var AllChat = Context.Chats;
            Random rand = new Random();
            int Id = rand.Next(AllChat.Count());
            return AllChat.AsNoTracking().Include(x => x.Avatar).FirstOrDefault(x => x.Id == Id);
        }
        public User UserInfo()
        {
            string Email = ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail];
            var User = Context.Users.Include(x => x.Avatar).FirstOrDefault(x => x.Enail == Email);
            return User;
        }
        public void SaveChanges() => Context.SaveChanges();
        public void LogOut ()
        {
            var User = UserInfo();
            User.IsRegidtred = false;
            Context.SaveChanges();
        }
        public string DeleteGroup(int Id)
        {
            var Group = Context.Chats.FirstOrDefault(x => x.Id == Id);
            if (Group != null)
            {
                Context.Remove(Group);
                Context.SaveChanges();
                return $"Группа {Group.NameChat} успешно удаленна";
            }
            return "Ошибка";
        }
        public List<MessageInfoDto> LoadAllChatMessage(string GroupName)
        {
            var Chat = Context.Chats.AsNoTracking().Include(x => x.Messages).ThenInclude(x => x.ForwardedFrom).FirstOrDefault(x => x.NameChat == GroupName);

            var AllMessage = Chat.Messages.ToList();

            List<MessageInfoDto> AllMesagesListDto = new List<MessageInfoDto>();
            foreach (var message in AllMessage)
            {
                int hours = message.Timestamp.Value.Hour;
                int minutes = message.Timestamp.Value.Minute;
                var timestamp = new TimeSpan(hours,minutes,0);
                var MessageInfoDtoInstance = new MessageInfoDto
                {
                    Content = message.Content,
                    Timestamp = timestamp,
                    ForwardedUserName = message.ForwardedFrom.UserName
                };
                AllMesagesListDto.Add(MessageInfoDtoInstance);
            }
            return AllMesagesListDto;
        }
    }
}