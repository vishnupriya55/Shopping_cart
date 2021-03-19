using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Shopping_cart.Configuration.Dto;

namespace Shopping_cart.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Shopping_cartAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
