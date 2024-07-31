namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface IFormRegistrationAndAuthorizationService
    {
         string FormRegistration(string UserName, string Password, string Email);
         string FormLogin(string Email, string Password);
    }
}
