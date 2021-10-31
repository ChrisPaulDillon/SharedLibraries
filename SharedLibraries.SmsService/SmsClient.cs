using System;
using System.Threading.Tasks;
using SharedLibraries.SmsService.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;

namespace SharedLibraries.SmsService
{
    public class SmsClient : ISmsClient
    {
        private readonly ITwilioSettings _settings;

        public SmsClient(ITwilioSettings settings)
        {
            _settings = settings;
        }

        public void SendCustomSmsMessage(string body, string phoneNumber)
        {
            MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }

        public async Task<string> SendPhoneNumberVerification(string phoneNumber)
        {
            try
            {
                var verification = await VerificationResource.CreateAsync(
                    to: phoneNumber,
                    channel: "sms",
                    pathServiceSid: _settings.VerificationServiceSID
                );

                return verification.Status;
            }
            catch
            {
                return "Error";
            }
        }

        public async Task<bool> VerifyPhoneNumber(string phoneNumber, string code)
        {
            try
            {
                var verification = await VerificationCheckResource.CreateAsync(
                    to: phoneNumber,
                    code: code,
                    pathServiceSid: _settings.VerificationServiceSID
                );

                if (verification.Status == "approved")
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
