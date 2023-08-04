using Webapi.Domain.src.Entities;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Order GetOwnOrders(User user);
    }
}