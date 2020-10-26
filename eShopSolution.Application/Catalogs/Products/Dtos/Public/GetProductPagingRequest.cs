using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalogs.Products.Dtos.Public
{
    public class GetProductPagingRequest :PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
