using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class SendEmailOrRequest : ISendEmailOrRequestService
    {
        IGetDataFromConfigurationService GetDataConfig;
        public SendEmailOrRequest(IGetDataFromConfigurationService GetDataConfig)
        {
            this.GetDataConfig = GetDataConfig;
        }
        /*Отправка кода авторизации на почту*/
        public string SendCodeAuthentification(string Email)
        {
            string Sender = GetDataConfig.GetSenderEmail();
            string AppPassword = GetDataConfig.GetAppPassword();
        //    var smtpClient = new SmtpClient("smtp.example.com")
        //{
        //    Port = 587,
        //    Credentials = new NetworkCredential("your_username", "your_password"),
        //    EnableSsl = true,
        //};
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                Random rand = new Random();
                string Password = Convert.ToString(rand.Next(1000000));
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Sender,AppPassword);
                MailMessage message = new MailMessage(Sender, Email)
                {
                    Subject = "Ldis",
                    Body = $"your authentication code to log into your account {Password} "
                };
                try
                {
                    smtpClient.Send(message);
                    return Password;
                }
                catch (Exception exeption)
                {
                    Log.Error($"Error send message - DateTime {DateTime.Now} error message {exeption.Message}");
                }
                return " ";
            };
        }

        public async Task<T> SendHttpRequest<T>(HttpMethod httpMethod, string endpoint, string accessToken = null, Dictionary<string, string> queryParams = null, HttpContent httpContent = null)
        {
            var url = queryParams != null
              ? QueryHelpers.AddQueryString(endpoint, queryParams)
              : endpoint;

            var request = new HttpRequestMessage(httpMethod, url);

            if (accessToken != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            using var httpClient = new HttpClient();
            using var response = await httpClient.SendAsync(request);

            var resultJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {    
                try
                {
                    throw new HttpRequestException(resultJson);
                }
                catch (Exception Exception)
                {
                    var ErrorDate = DateTime.Now;
                    Log.Error($"Error {response.StatusCode} DateTime Error - {ErrorDate} - more information about error {Exception.Message}");
                    throw;
                }
            }
            var result = JsonConvert.DeserializeObject<T>(resultJson);
            return result;
        }

        public async Task<T> SendPostRequest<T>(string endpoint, Dictionary<string, string> QueryParams)
        {
            var httpContent = new FormUrlEncodedContent(QueryParams);
            return await SendHttpRequest<T>(HttpMethod.Post, endpoint, httpContent: httpContent);
        }
    }
}
