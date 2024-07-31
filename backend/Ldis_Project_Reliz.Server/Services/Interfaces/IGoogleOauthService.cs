using Ldis_Project_Reliz.Server.Models.BusinesModel;

namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface IGoogleOauthService
    {
        Task<TokenResult> GetRefreshToken(string RefreshToken);
        string GeneratedUrlOauthServer(string scope, string redirectUrl, string CodeChallenge, string Codeverifier);
        Task<Dictionary<string, string>> GetUserDataWithAccessToken(string AccessToken);
        Task<(Dictionary<string, string>, HttpContext)> GetUserDataWithAccessToken(string AccessToken, HttpContext context);
        Task<TokenResult> ExchangeCodeOnToken(string Code, string CodeVerification, string RedirectUrl);
        Task<string> AuthentificationOrRegisterUser(Dictionary<string, string> DataUserFromAccesToken);
        Task<string> AuthentificationOrRegisterUser(Dictionary<string, string> DataUserFromAccesToken, HttpContext context);
    }
}
