using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Ldis_Project_Reliz.Server.BusinesStaticMethod
{
    public static class Sha256Encoder
    {
        /*Генерация CodeChallenge*/
        public static string Sha256Compute(string codeVerification)
        {
            using var sha256 = SHA256.Create();
            var ChallengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerification));
            var CodeChallenge = Base64UrlEncoder.Encode(ChallengeBytes);
            return CodeChallenge;
        }
    }
}
