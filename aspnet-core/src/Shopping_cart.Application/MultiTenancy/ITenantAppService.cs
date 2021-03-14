using Abp.Application.Services;
using Shopping_cart.MultiTenancy.Dto;

namespace Shopping_cart.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

