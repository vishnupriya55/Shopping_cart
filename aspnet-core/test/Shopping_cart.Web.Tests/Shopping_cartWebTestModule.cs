using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_cart.EntityFrameworkCore;
using Shopping_cart.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Shopping_cart.Web.Tests
{
    [DependsOn(
        typeof(Shopping_cartWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Shopping_cartWebTestModule : AbpModule
    {
        public Shopping_cartWebTestModule(Shopping_cartEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Shopping_cartWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Shopping_cartWebMvcModule).Assembly);
        }
    }
}