using eShopSolution.Application.Catalogs.Products.Dtos;
using eShopSolution.Application.Catalogs.Products.Dtos.Public;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogs.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategory(GetProductPagingRequest request);
    }
}
