using Webapi.Domain.src.Entities;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IUserRepo : IBaseRepo<User>
    {
        User CreateAdmin(User user);
    }
}