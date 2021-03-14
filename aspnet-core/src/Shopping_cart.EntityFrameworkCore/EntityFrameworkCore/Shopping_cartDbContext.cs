using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Shopping_cart.Authorization.Roles;
using Shopping_cart.Authorization.Users;
using Shopping_cart.MultiTenancy;
using Shopping_cart.Models;
using System.Linq;

namespace Shopping_cart.EntityFrameworkCore
{
    public class Shopping_cartDbContext : AbpZeroDbContext<Tenant, Role, User, Shopping_cartDbContext>
    {
    /* Define a DbSet for each entity of the application */
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }

    public Shopping_cartDbContext(DbContextOptions<Shopping_cartDbContext> options)
            : base(options)
        {
        }
    
    //public DbSet<Order> Order { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Product>(a =>  a.ToTable("VishnupriyaProducts") ) ;
      //modelBuilder.Entity<Product>(a =>  a.hasco(t=>t.Description.) ) ;

     foreach (var property in modelBuilder.Model.GetEntityTypes()
    //.Where(t => t.ClrType == typeof(Product) || t.ClrType == typeof(Category))
    .SelectMany(t => t.GetProperties())
    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
      {
        // EF Core 1 & 2
        //property.Relational().ColumnType = "decimal(18, 6)";

        // EF Core 3
        //property.SetColumnType("decimal(18, 6)");

        //EF Core 5
        property.SetPrecision(18);
        property.SetScale(6);
      }

    }
  }
}
