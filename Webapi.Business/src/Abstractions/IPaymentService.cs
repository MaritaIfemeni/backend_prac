using Webapi.Business.src.Dtos;
using Webapi.Domain.src.Entities;

namespace Webapi.Business.src.Abstractions
{
    public interface IPaymentService : IBaseService<Payment, PaymentDto>
    {
        //PaymentDto GetOwnerPayment(string id);  --Sasme logic as getOneById? No need to have this in service?
    }
}