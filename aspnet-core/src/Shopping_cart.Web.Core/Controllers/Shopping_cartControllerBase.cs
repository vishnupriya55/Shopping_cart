using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Shopping_cart.Controllers
{
    public abstract class Shopping_cartControllerBase: AbpController
    {
        protected Shopping_cartControllerBase()
        {
            LocalizationSourceName = Shopping_cartConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
