using Webapi.Domain.src.Entities;

namespace Webapi.Domain.src.RepoInterfaces
{
    public interface IPaymentRepo : IBaseRepo<Payment>
    {
        Payment GetOwnPayments (User user);
    }
}