using Abp.Authorization;
using Shopping_cart.Authorization.Roles;
using Shopping_cart.Authorization.Users;

namespace Shopping_cart.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
