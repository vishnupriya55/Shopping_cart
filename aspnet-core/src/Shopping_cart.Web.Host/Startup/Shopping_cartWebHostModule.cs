using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_cart.Configuration;

namespace Shopping_cart.Web.Host.Startup
{
    [DependsOn(
       typeof(Shopping_cartWebCoreModule))]
    public class Shopping_cartWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Shopping_cartWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Shopping_cartWebHostModule).GetAssembly());
        }
    }
}
