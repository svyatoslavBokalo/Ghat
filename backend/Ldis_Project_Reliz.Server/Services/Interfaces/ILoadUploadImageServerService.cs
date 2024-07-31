using Microsoft.AspNetCore.Mvc;

namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface ILoadUploadImageServerService
    {
        Dictionary<string,string> LoadUserAvatar(IFormFile file,string UserName);
        Dictionary<string, string> LoadChatAvatar(IFormFile file, string ChatName);
        object UploadImage(string ImageLInk);
    }
}
