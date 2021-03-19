using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Shopping_cart.EntityFrameworkCore
{
    public static class Shopping_cartDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Shopping_cartDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Shopping_cartDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
