using Webapi.Business.src.Dtos;

namespace Webapi.Business.src.Abstractions
{
    public interface IAuthService
    {
        Task<string> VerifyCredentials(UserCredentialsDto credentials);
    }
}