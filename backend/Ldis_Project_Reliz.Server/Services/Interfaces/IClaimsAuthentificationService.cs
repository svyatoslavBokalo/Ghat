namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface IClaimsAuthentificationService
    {
        Task Authentification(string Email);
        Task Authentification(string Email, HttpContext context);
        Task LogOut();
    }
}
