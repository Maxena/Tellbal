using Kavenegar.Models;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IOtpService
    {
        SendResult GetOneTimePassword(string mobileNumber);
        bool CheckOneTimePassword(string mobileNumber, int verficationCode);
    }
}