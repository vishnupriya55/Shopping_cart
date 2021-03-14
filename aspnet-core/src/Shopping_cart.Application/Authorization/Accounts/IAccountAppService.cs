using System.Threading.Tasks;
using Abp.Application.Services;
using Shopping_cart.Authorization.Accounts.Dto;

namespace Shopping_cart.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
