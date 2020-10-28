using eShopSolution.ViewModels.Catalog;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogs.Products
{
    public interface IManagedProductService
    {
        
        Task<int> Create(ProductCreateRequest request, string langugeID);
        Task<int> Update(ProductUpdateRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addQuatity);
        Task AddViewCount(int productId);
        /// <summary>
        /// Xóa Sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> Delete(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdatesImages(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> getListImages(int productId);
        Task<ProductViewModel> GetById(int productId, string languageId);
    }
}
