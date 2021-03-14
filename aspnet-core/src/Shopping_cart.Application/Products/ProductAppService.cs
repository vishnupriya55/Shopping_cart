using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Shopping_cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Shopping_cart.Products
{
  public class ProductAppService : Shopping_cartAppServiceBase, IProductAppService
  {
    private readonly IRepository<Product> _productRepository;

    public ProductAppService(IRepository<Product> productRepository)
    {
      _productRepository = productRepository;
    }

    public async Task<ListResultDto<ProductListDto>> GetAll(GetAllProductsInput input)
    {
      var products = await _productRepository
                .GetAll()
                .WhereIf(!input.ProductName.IsNullOrEmpty(), t => t.Name == input.ProductName)
                //.WhereIf(!input.Description.IsNullOrEmpty(), t => t.Description == input.Description)
                //.WhereIf(input.UpperLimit != 0, t => t.Price <= input.UpperLimit)
                //.WhereIf(input.LowerLimit != 0, t => t.Price >= input.LowerLimit)

                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

      return new ListResultDto<ProductListDto>(
          ObjectMapper.Map<List<ProductListDto>>(products)
      );
      throw new NotImplementedException();
    }

    public void CreateProduct(CreateProductInput input)
    {
      var product = ObjectMapper.Map<Product>(input);
      _productRepository.Insert(product);
     
    }

    public void UpdateProduct(UpdateProductInput input)
    {
      var product = _productRepository.Get(input.Id);
      ObjectMapper.Map(input, product);

    }

    public async Task DeleteProduct(DeleteProductInput input)
    {
      await _productRepository.DeleteAsync(input.Id);

      //throw new NotImplementedException();
    }


    //public Task DeleteProduct(ProductListDto input)
    //{
    //  throw new NotImplementedException();
    //}
    public PagedResultDto<ProductListDto> GetProductItems(GetAllProductsInput input)
    {
      var productQuery = _productRepository
      .GetAll()
      .WhereIf(
          !input.ProductName.IsNullOrEmpty(),
          p => p.Name.Contains(input.ProductName) 
      );

      var pagedResult = productQuery.OrderBy(p => p.Name)
       .Skip(input.SkipCount)
       .Take(input.MaxResultCount)

       .ToList();
      var totalcount = productQuery.Count();
      var productmapped = ObjectMapper.Map<List<ProductListDto>>(pagedResult);
      return new PagedResultDto<ProductListDto>(totalcount, productmapped);
    }


  }
}
