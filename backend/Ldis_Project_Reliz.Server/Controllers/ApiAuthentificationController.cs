using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Project_Reliz.Server.Services.Realization;
using Microsoft.AspNetCore.Mvc;

namespace Ldis_Project_Reliz.Server.Controllers
{
    [ApiController]
    [Route("oauth/[controller]")]
    public class ApiAuthentificationController : ControllerBase
    {
        IReturnUrlOauthServerService ReturnUrlOauthServer;
        IFormRegistrationAndAuthorizationService RegAndLog;
        public ApiAuthentificationController(IReturnUrlOauthServerService ReturnUrlOauthServer, IFormRegistrationAndAuthorizationService RegAndLog)
        {
            this.RegAndLog = RegAndLog;
            this.ReturnUrlOauthServer = ReturnUrlOauthServer;
        }
        [HttpGet]
        public IActionResult GetUrlOauthServer()
        {
           return Ok(ReturnUrlOauthServer.ReturnUrlOauthServer());
        }

        [HttpPost("login/{Email},{Password}")]
        public IActionResult LoginForm(string Email, string Password)
        {
            string result =  RegAndLog.FormLogin(Email,Password);
            return Ok(result);
        }

        [HttpPost("registration/{UserName},{Password},{Email}")]
        public IActionResult RegistrationForm(string UserName,string Password,string Email)
        {
           string result = RegAndLog.FormRegistration(UserName,Password,Email);
            return Ok(result);
        }
    }
}
