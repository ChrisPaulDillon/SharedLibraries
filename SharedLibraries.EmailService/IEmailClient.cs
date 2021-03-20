using System.Threading.Tasks;
using SharedLibraries.EmailService.Models;

namespace SharedLibraries.EmailService
{
    public interface IEmailClient
    {
        public Task SendEmailAsync(EmailMessage message);
    }
}
