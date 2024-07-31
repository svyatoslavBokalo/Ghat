using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Models.BusinesModel;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Ldis_Project_Reliz.Server.Controllers
{

    [ApiController]
    [Route("main/[controller]")]
    public class ApiMainController : ControllerBase
    {
        IRepository Repository;
        ILoadUploadImageServerService LoadUploadImage;
        IHttpContextAccessor ContextAccessor;
        public ApiMainController(IRepository Repository, ILoadUploadImageServerService LoadUploadImage, IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
            this.LoadUploadImage = LoadUploadImage;
            this.Repository = Repository;
        }
        [HttpGet("getRandomChat")]
        public IActionResult GetRandomChat()
        {
            if (ContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var Chat = Repository.RandomChat();
                var ChatInfoDtoInstance = new ChatInfoDto
                {
                    Description = Chat.Description,
                    CreateDate = Chat.CreatDate.Value,
                    CountUsers = Chat.CountUsers.Value,
                    NameChat = Chat.NameChat
                };
                string link = Chat.Avatar.Link;
                ContextAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.AvatarChatLinkSession,link);
                string responce = JsonSerializer.Serialize(ChatInfoDtoInstance);
                return Ok(responce);
            }
            else
            {
                return StatusCode(401);
            }
        }
        [HttpGet("getAvatarRandomChat")]
        public IActionResult GetAvatarRandomChat()
        {
            string linkImage = ContextAccessor.HttpContext.Request.Cookies[DataToCacheSessionCookieKey.AvatarChatLinkSession];
            var avatar = LoadUploadImage.UploadImage(linkImage);
            if (avatar.GetType() == typeof(string))
            {
                return Ok(avatar);
            }
            else if (avatar.GetType() == typeof(string))
            {
                return File((FileStream)avatar, "application/octet-stream", "ChatAvatar.jpg");
            }
            return StatusCode(505);
        }
        [HttpGet("getAllChats")]
        public IActionResult GetAllChats()
        {
            return Ok();
        }

        [HttpPost("getChat/{ChatName}")]
        public IActionResult GetChat (string ChatName)
        {
            if (ContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var Chats = Repository.FindChat(ChatName);
                var Responce = JsonSerializer.Serialize(Chats);
                return Ok(Responce);
            }
            else
            {
                return StatusCode(401);
            }
        }
        [HttpGet]

        [HttpPost("createChat/{ChatName},{CountUsers},{AutoDelete},{ChatGenre},{Describing},{Visible}")]
        public IActionResult CreateChat (string ChatName,
            int CountUsers,
            bool AutoDelete,
            string ChatGenre,
            string Describing,string Visible)
            {
            if (ContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var file = HttpContext.Request.Form.Files["image"];
                Repository.CreateNewGroup(ChatName, Describing, CountUsers, AutoDelete, ChatGenre, Visible, file);
                return Ok();
            }
            else
            {
                return StatusCode(401);
            }
          
        }


        [HttpPost("deleteGroup/{Id}")]
        public IActionResult DeleteGroup(int Id)
        {
            if (ContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string result = Repository.DeleteGroup(Id);
                return Ok(result);
            }
            else
            {
                return StatusCode(401);
            }
        }


        [HttpPost("getAllChatMessages/{ChatName}")]
        public IActionResult ViewAllMessages (string ChatName)
        {
            var AllMessagesList = Repository.LoadAllChatMessage(ChatName);
            string responceJson = JsonSerializer.Serialize(AllMessagesList);
            return Ok(responceJson);
        }
    }
      
}
