using System.Threading.Tasks;
using SharedLibraries.AuthenticationService.Models;

namespace SharedLibraries.AuthenticationService
{
    public interface IFacebookAuthService
    {
	    Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
