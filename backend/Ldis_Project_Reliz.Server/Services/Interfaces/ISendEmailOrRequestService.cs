namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface ISendEmailOrRequestService
    {
        string SendCodeAuthentification(string Email);
        Task<T> SendPostRequest<T>(string endpoint, Dictionary<string, string> QueryParams);
        Task<T> SendHttpRequest<T>(HttpMethod httpMethod, string endpoint, string accessToken = null, Dictionary<string, string> queryParams = null, HttpContent httpContent = null);
    }
}

