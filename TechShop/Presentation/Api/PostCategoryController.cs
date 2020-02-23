using AutoMapper;
using Presentation.Infrastructure.Core;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TechShop.Model.Models;
using TechShop.Service;
using Presentation.Infrastructure.Extension;

namespace Presentation.Api
{
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            _postCategoryService = postCategoryService;
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryvm)
        {
            return CreateHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryvm);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }

                return response;
            });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryId = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategoryId.UpdatePostCategory(postCategoryVm);

                    _postCategoryService.Update(postCategoryId);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }


        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponseMessage(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponseMessage(request, () =>
            {

                var listCategory = _postCategoryService.GetAll();

                var listPostCategoryvm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryvm);

                return response;

            });
        }
    }
}