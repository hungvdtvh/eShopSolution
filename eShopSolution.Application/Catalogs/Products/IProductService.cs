using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogs.Products
{
    public interface IProductService
    {
        
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addQuatity);
        Task AddViewCount(int productId);
        Task<int> Delete(int productId);
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<ProductVm> GetById(int productId, string languageId);
        Task<int> AddImages(int productId, ProductImageCreateRequest reuest);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdatesImages(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<PagedResult<ProductVm>> GetAllByCategory(GetPublicProductPagingRequest request, string langugeId);
        Task<ApiResult<bool>> CategoriAssign(int id, CategoryAssignRequest request);
    }
}
