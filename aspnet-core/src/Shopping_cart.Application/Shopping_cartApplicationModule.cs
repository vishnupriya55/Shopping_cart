using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_cart.Authorization;

namespace Shopping_cart
{
    [DependsOn(
        typeof(Shopping_cartCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Shopping_cartApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Shopping_cartAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Shopping_cartApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
