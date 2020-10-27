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
        /// <summary>
        /// Tạo mới sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> Create(ProductCreateRequest request);
        /// <summary>
        /// Cập nhật sản phẩm ( không cập nhật giá)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> Update(ProductUpdateRequest request);
        /// <summary>
        /// Cập nhật giá sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newPrice"></param>
        /// <returns></returns>
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        /// <summary>
        /// Cập nhật số lượng tồn kho
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addQuatity"></param>
        /// <returns></returns>
        Task<bool> UpdateStock(int productId, int addQuatity);
        /// <summary>
        /// Tăng viewCount lên +1
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>        
        ///
        Task AddViewCount(int productId);
        /// <summary>
        /// Xóa Sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> Delete(int productId);
        /// <summary>
        /// Lấy ra danh sách sản phẩm có phân trang
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdatesImages(int imageId, string caption, bool isDefault);
        Task<List<ProductImageViewModel>> getListImages(int productId);
    }
}
