using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalogs.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {

            _productService = productService;
        }

        [HttpGet("getAll-pagging")]
        public async Task<IActionResult> GetAllPagging([FromQuery] GetPublicProductPagingRequest request, string langugeId)
        {
            var product = await _productService.GetAllByCategory(request, langugeId);
            return Ok(product);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPagging([FromQuery] GetManageProductPagingRequest request)
        {
            var product = await _productService.GetAllPaging(request);
            return Ok(product);
        }
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null) return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost()]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var productId = await _productService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }

            var product = await _productService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var Result = await _productService.UpdatePrice(productId, newPrice);
            if (!Result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("{productId}/add-image")]
        public async Task<IActionResult> AddImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.AddImages(productId, request);
            if (result == 0)
            {
                return BadRequest();
            }

            var productImage = await _productService.GetImageById(result);
            return CreatedAtAction(nameof(GetImageById), new { id = result }, productImage);
            //return Ok();
        }

        [HttpDelete("{imageId}/remove-image")]
        public async Task<IActionResult> DeleteRemoveImages(int imageId)
        {
            var affectedResult = await _productService.RemoveImages(imageId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{imageId}/update-image")]
        public async Task<IActionResult> UpdatesImages(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var affectedResult = await _productService.UpdatesImages(imageId, request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("{productId}/get-list-image")]
        public async Task<IActionResult> GetListImages(int productId)
        {
            var result = await _productService.GetListImages(productId);
            if (result == null) return BadRequest("Cannot find product");
            return Ok(result);
        }

        [HttpGet("{imageId}/gett-image-byId")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var res = await _productService.GetImageById(imageId);
            if (res == null) return BadRequest("Cannot find product");
            return Ok(res);
        }

        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.CategoriAssign(id, request);
            if (result.IsSucessed)
                return Ok(result);
            else return BadRequest(result);
        }

    }
}
