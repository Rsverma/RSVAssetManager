using RAMApi.Library.Models;

namespace RAMApi.Library.Internal.FixAccess
{
    public interface IFixDataAccess
    {
        void SendOrder(OrderModel order);
    }
}