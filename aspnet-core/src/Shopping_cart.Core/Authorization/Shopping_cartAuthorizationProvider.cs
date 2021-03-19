using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Shopping_cart.Authorization
{
    public class Shopping_cartAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Products_View, L("ProductsView"), multiTenancySides: MultiTenancySides.Tenant);


            context.CreatePermission(PermissionNames.Pages_Seller, L("Seller"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Seller_Products_View, L("SellerProductsView"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Seller_Products_Create, L("SellerProductsCreate"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Seller_Products_Edit, L("SellerProductsEdit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Seller_Products_Delete, L("SellerProductsDelete"), multiTenancySides: MultiTenancySides.Tenant);




            context.CreatePermission(PermissionNames.Pages_Customer, L("Customer"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Customer_Products_View, L("CustomerProductsView"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Customer_Products_Add, L("CustomerProductsAdd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Customer_AddtoCart_View, L("CustomerAddtoCartView"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Customer_AddtoCart_Delete, L("CustomerAddtoCartDelete"), multiTenancySides: MultiTenancySides.Tenant);

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Shopping_cartConsts.LocalizationSourceName);
        }
    }
}
