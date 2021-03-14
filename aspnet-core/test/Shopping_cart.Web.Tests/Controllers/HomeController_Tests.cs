using System.Threading.Tasks;
using Shopping_cart.Models.TokenAuth;
using Shopping_cart.Web.Controllers;
using Shouldly;
using Xunit;

namespace Shopping_cart.Web.Tests.Controllers
{
    public class HomeController_Tests: Shopping_cartWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}