using eShopSolution.ViewModels.Catalog;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogs.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategory(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
