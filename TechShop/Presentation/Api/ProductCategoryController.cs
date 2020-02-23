using AutoMapper;
using Presentation.Infrastructure.Core;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechShop.Model.Models;
using TechShop.Service;

namespace Presentation.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService ,IProductCategoryService productCategoryService):base(errorService)
        {
            _productCategoryService = productCategoryService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponseMessage(request, () =>
            {
                var model = _productCategoryService.GetAll();

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });


        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize)
        {
            return CreateHttpResponseMessage(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keyword);

                totalRow= model.Count();

                var query = model.OrderByDescending(x=>x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var pagination = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)(totalRow / pageSize))
                };

                var response = request.CreateResponse(HttpStatusCode.OK, pagination);

                return response;
            });


        }
    }
}
