namespace Ldis_Project_Reliz.Server.Services.Interfaces
{
    public interface IGetDataFromConfigurationService
    {
        string GetClientId();
        string GetClientSecret();
        string GetSenderEmail();
        string GetAppPassword();
        string GetDataBaseConnectionString();
    }
}
