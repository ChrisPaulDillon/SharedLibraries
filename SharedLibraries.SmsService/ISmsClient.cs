using System.Threading.Tasks;

namespace SharedLibraries.SmsService
{
    public interface ISmsClient
    {
        void SendCustomSmsMessage(string body, string phoneNumber);
        Task<string> SendPhoneNumberVerification(string phoneNumber);
        Task<bool> VerifyPhoneNumber(string phoneNumber, string code);
    }
}
