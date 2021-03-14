using System.Threading.Tasks;
using Shopping_cart.Configuration.Dto;

namespace Shopping_cart.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
