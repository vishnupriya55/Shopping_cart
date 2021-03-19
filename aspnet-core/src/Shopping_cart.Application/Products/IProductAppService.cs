using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace Shopping_cart.Products
{
  public interface IProductAppService : IApplicationService
  {
    Task<ListResultDto<ProductListDto>> GetAll(GetAllProductsInput input);
    void CreateProduct(CreateProductInput input);

    void UpdateProduct(UpdateProductInput input);

    Task DeleteProduct(DeleteProductInput input);

  }
}
