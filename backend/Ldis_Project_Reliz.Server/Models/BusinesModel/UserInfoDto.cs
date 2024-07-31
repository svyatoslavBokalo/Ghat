using Microsoft.AspNetCore.Mvc;

namespace Ldis_Project_Reliz.Server.Models.BusinesModel
{
    public class UserInfoDto 
    {
        public string Email { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public object _Avatar;
        public object Avatar {
            get { return _Avatar; }
            set
            {
                if (value.GetType() == typeof(string) || value.GetType() == typeof(FileStreamResult))
                {
                    _Avatar = value;
                }
                else
                {
                    throw new Exception("Type is not correct");
                }
            } 
        }
    }
}
