using RAMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAMDesktopUI.Library.Api
{
    public interface IFillEndpoint
    {
        Task<List<FillModel>> GetAll();
        Task PostFill(FillModel fill);
    }
}