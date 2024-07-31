using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class LoadUploadImageServer : ILoadUploadImageServerService
    {
        /*Загрузка аватара для группы в файловую систему*/
        public Dictionary<string, string> LoadChatAvatar(IFormFile file, string ChatName)
        {
            int CountSymbolsChatName = ChatName.Length;
            StringBuilder builder = new StringBuilder(ChatName);
            builder.Insert(CountSymbolsChatName, "ChatAvatar.jpg");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\teamchallenge_chat\\backend\\Ldis_Project_Reliz.Server\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            var AvatarInfo = new Dictionary<string, string>()
            {
                {"ImageName",ImageName },
                {"FullPathToFile",FullPathToFile }
            };
            return AvatarInfo;
        }
        /*Загрузка аватара для юзера в файловую систему*/
        public Dictionary<string, string> LoadUserAvatar(IFormFile file,string UserName)
        {
            int CountSymbolsChatName = UserName.Length;
            StringBuilder builder = new StringBuilder(UserName);
            builder.Insert(CountSymbolsChatName, "UserAvatar.jpg");
            string ImageName = Convert.ToString(builder);
            string FullPathToFile = $"D:\\teamchallenge_chat\\backend\\Ldis_Project_Reliz.Server\\Images\\{ImageName}";
            using (Bitmap bitmap = new Bitmap(file.OpenReadStream()))
            {
                bitmap.Save(FullPathToFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            var AvatarInfo = new Dictionary<string, string>()
            {
                {"ImageName",ImageName },
                {"FullPathToFile",FullPathToFile }
            };
            return AvatarInfo;
        }
        /*Получение изображения из файловой системы по ссылке*/
        public object UploadImage(string ImageLink)
        {
            if (ImageLink == null)
            {
                return "https://cdn-icons-png.flaticon.com/512/69/69589.png";
            }
            FileStream fileStream = new FileStream(ImageLink, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
    }
}