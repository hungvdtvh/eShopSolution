using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogs.Products
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;

        public ProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {

            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name= request.Name,
                        Description= request.Description,
                        Details= request.Details,
                        SeoDescription= request.SeoDescription,
                        SeoAlias= request.SeoAlias,
                        SeoTitle= request.SeoTitle,
                        LanguageId=request.LanguageId
                    }
                }
            };
            //Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption="Thumbnail Image",
                        DateCreated= DateTime.Now,
                        FileSize=request.ThumbnailImage.Length,
                        ImagePath= await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var querry = from p in _context.Products
                         join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                         join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                         join c in _context.Categories on pic.CategoryId equals c.Id
                         where pt.LanguageId == request.LanguageId
                         select new { p, pt, pic };
            //2. Filter
            if (!string.IsNullOrEmpty(request.Keyword))
                querry = querry.Where(x => x.pt.Name.Contains(request.Keyword));
            if (request.CategoryId != null && request.CategoryId !=0)
            {
                querry = querry.Where(p => p.pic.CategoryId== request.CategoryId);
            }
            //3. Paging
            int toTalRow = await querry.CountAsync();
            var data = await querry
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //4. Select and projection

            var pageResult = new PagedResult<ProductVm>()
            {

                TotalRecords = toTalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pageResult;
        }
        public async Task<ProductVm> GetById(int productId, string langugeId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == langugeId);
            var productViewModel = new ProductVm()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount
            };
            return productViewModel;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = _context.ProductTranslations.FirstOrDefault(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null || productTranslation == null)
            {
                throw new EShopException($"Cannot find product with id: {request.Id}");
            }
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Details = request.Details;
            productTranslation.Description = request.Description;

            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateStock(int productId, int addQuatity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find product with id: {productId}");
            product.Stock = addQuatity;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product: {productId}");
            }
            var images = _context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddImages(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };
            if (request.ImageFile != null)
            {
                productImage.FileSize = request.ImageFile.Length;
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }
        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImages
                .Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ImagePath = i.ImagePath,
                    Caption = i.Caption,
                    IsDefault = i.IsDefault,
                    DateCreated = i.DateCreated,
                    SortOrder = i.SortOrder,
                    FileSize = i.FileSize
                }).ToListAsync();

        }
        public async Task<int> RemoveImages(int imageId)
        {
            var images = _context.ProductImages.FirstOrDefault(i => i.Id == imageId);
            await _storageService.DeleteFileAsync(images.ImagePath);
            _context.ProductImages.Remove(images);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdatesImages(int imageId, ProductImageUpdateRequest request)
        {
            var images = _context.ProductImages.FirstOrDefault(x => x.Id == imageId);
            if (images == null)
            {
                throw new EShopException($"Cannot find product with id: {imageId}");
            }
            images.FileSize = request.ImageFile.Length;
            images.ImagePath = await this.SaveFile(request.ImageFile);
            images.Caption = request.Caption;
            images.IsDefault = request.IsDefault;
            images.SortOrder = request.SortOrder;
            _context.ProductImages.Update(images);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new EShopException($"Cannot find an image with id {imageId}");
            var product = new ProductImageViewModel()
            {
                Id = image.Id,
                DateCreated = image.DateCreated,
                Caption = image.Caption,
                FileSize = image.FileSize,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return product;


        }
        public async Task<PagedResult<ProductVm>> GetAllByCategory(GetPublicProductPagingRequest request, string langugeId)
        {
            //1. Select join
            var querry = from p in _context.Products
                         join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                         join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                         join c in _context.Categories on pic.CategoryId equals c.Id
                         where pt.LanguageId == langugeId
                         select new { p, pt, pic };
            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                querry = querry.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            //3. Paging
            int toTalRow = await querry.CountAsync();
            var data = await querry
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //4. Select and projection

            var pageResult = new PagedResult<ProductVm>()
            {
                TotalRecords = toTalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pageResult;
        }
    }
}
