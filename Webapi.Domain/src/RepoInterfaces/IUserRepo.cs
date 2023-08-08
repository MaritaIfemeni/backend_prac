using Webapi.Domain.src.Entities;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> CreateAdmin(User user);
        Task<User> UpdatePassword(User user, string newPassword);
        Task<User> FindByEmail(string email);
    }
}