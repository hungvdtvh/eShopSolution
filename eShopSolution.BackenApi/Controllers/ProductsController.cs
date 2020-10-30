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
        private readonly IPublicProductService _publicProductService;
        private readonly IManagedProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManagedProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet("getAll-pagging")]
        public async Task<IActionResult> GetAllPagging([FromQuery] GetPublicProductPagingRequest request, string langugeId)
        {
            var product = await _publicProductService.GetAllByCategory(request, langugeId);
            return Ok(product);
        }
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null) return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost("add-product/{languageId}")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request, string languageId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var productId = await _manageProductService.Create(request, languageId);
            if (productId == 0)
            {
                return BadRequest();
            }

            var product = await _manageProductService.GetById(productId, languageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var Result = await _manageProductService.UpdatePrice(productId, newPrice);
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
            var result = await _manageProductService.AddImages(productId, request);
            if (result == 0)
            {
                return BadRequest();
            }

            var productImage = await _manageProductService.GetImageById(result);
            return CreatedAtAction(nameof(GetImageById), new { id = result }, productImage);
            //return Ok();
        }

        [HttpDelete("{imageId}/remove-image")]
        public async Task<IActionResult> DeleteRemoveImages(int imageId)
        {
            var affectedResult = await _manageProductService.RemoveImages(imageId);
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
            var affectedResult = await _manageProductService.UpdatesImages(imageId, request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("{productId}/get-list-image")]
        public async Task<IActionResult> GetListImages(int productId)
        {
            var result = await _manageProductService.GetListImages(productId);
            if (result == null) return BadRequest("Cannot find product");
            return Ok(result);
        }

        [HttpGet("{imageId}/gett-image-byId")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var res = await _manageProductService.GetImageById(imageId);
            if (res == null) return BadRequest("Cannot find product");
            return Ok(res);
        }

    }
}
