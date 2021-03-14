using System.Threading.Tasks;
using Abp.Application.Services;
using Shopping_cart.Sessions.Dto;

namespace Shopping_cart.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
