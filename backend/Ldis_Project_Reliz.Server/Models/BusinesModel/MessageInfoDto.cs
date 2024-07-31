namespace Ldis_Project_Reliz.Server.Models.BusinesModel
{
    public class MessageInfoDto
    {
        public string Content { get; set; }
        public TimeSpan Timestamp { get; set; }
        public string ForwardedUserName { get; set; }
    }
}
