using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shopping_cart.Configuration;
using Shopping_cart.Web;

namespace Shopping_cart.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Shopping_cartDbContextFactory : IDesignTimeDbContextFactory<Shopping_cartDbContext>
    {
        public Shopping_cartDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Shopping_cartDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Shopping_cartDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Shopping_cartConsts.ConnectionStringName));

            return new Shopping_cartDbContext(builder.Options);
        }
    }
}
