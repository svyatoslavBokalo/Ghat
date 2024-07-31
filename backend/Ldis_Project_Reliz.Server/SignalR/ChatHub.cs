using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace Ldis_Project_Reliz.Server.SignalR
{
    public class ChatHub : Hub
    {
        IHttpContextAccessor HttpContext;
        IRepository Repository;
        public ChatHub(IRepository Repository, IHttpContextAccessor HttpContext)
        {
            this.HttpContext = HttpContext;
            this.Repository = Repository;
        }
        public async Task Enter(string UserName,string GroupName)
        {
            bool succsesAddedResult;
            string responce = Repository.AddToGroup(UserName, GroupName, HttpContext.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail],out succsesAddedResult);
            if (succsesAddedResult == false)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = "";
                    string postData = responce;
                    HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");
                }
            }
            else if (succsesAddedResult == true)
            {
                Clients.Group(GroupName).SendAsync("Notify", $"{UserName} додався до группи");
                await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            }
        }
        public async Task Send (string UserName,string GroupName,string Message)
        {
            Clients.Group(GroupName).SendAsync("Receive",Message,UserName);
            Repository.AddMessage(Message,GroupName,UserName, "illanazarov966@gmail.com");
        }
        public async Task ExitGroup (string GroupName,string UserName)
        {
            Clients.Group(GroupName).SendAsync("Receive",$"{UserName} видалився з чату");
            Repository.ExitFromGroup(HttpContext.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail],GroupName);
        }
        public override Task OnConnectedAsync()
        {
            Repository.SetStatusConnected(HttpContext.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail]);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Repository.SetStatusDisconnected(HttpContext.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.EmailForAllOperationWithEmail]);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
