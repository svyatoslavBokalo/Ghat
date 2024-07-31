using Ldis_Project_Reliz.Server.Models.BusinesModel;
using Ldis_Team_Project.Models;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace Ldis_Project_Reliz.Server.Repository
{
    public interface IRepository
    {
        Image AddNewImage(string ImageCode, string ImageLink);
        Task<bool> FindUserForСheckExistence(string Email);
        bool FindUserForСheckExistenceRegistration(string Email, string Password);
        bool FindUserForСheckExistenceLogin(string Email, string Password);
        void CreateNewUser(string Email, string UserName, string Password, string ImageLink);
        void CreateNewGroup(string NameGroup, string Description, int CountUsers, bool AutoDeleting, string Genre, string Visible, IFormFile file);
        string AddToGroup(string UserName, string GroupName, string Email, out bool sucssesfulAdded);
        Task AddMessage(string Message, string GroupName, string UserName, string Email);
        void SetStatusConnected(string Email);
        void SetStatusDisconnected(string Email);
        void ExitFromGroup(string Email, string ChatName);
        User FindUserByEmailForDeletedTimer(string Email);
        List<Chat> FindChat(string NameChat);
        void UptadeUserAvatar(IFormFile file);
        string ChangeUserName(string UserName);
        string ChangePassword(string Password);
        string DeleteAccount();
        Chat RandomChat();
        User UserInfo();
        void SaveChanges();
        void LogOut();
        string DeleteGroup(int Id);
        public List<MessageInfoDto> LoadAllChatMessage(string GroupName);
    }
}