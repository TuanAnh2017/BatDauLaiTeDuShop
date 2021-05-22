using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;
using TeduShop.Web.Infrastructure.Extensions;
using System.Collections.Generic;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;
        private ILogErrorService _logError;

        public PostCategoryController(ILogErrorService logError, IPostCategoryService postCategory) : base(logError)
        {
            //this._logError = logError;
            this._postCategoryService = postCategory;
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreatedHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVm);
                    var Category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, Category);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreatedHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var postCategory = _postCategoryService.GetbyId(postCategoryVm.ID);
                    postCategory.UpdatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int Id)
        {
            return CreatedHttpResponse(request, () =>
           {
               HttpResponseMessage response = null;
               if (ModelState.IsValid)
               {
                   _postCategoryService.DeleteByID(Id);
                   _postCategoryService.Save();

                   response = request.CreateResponse(HttpStatusCode.OK);
               }
               else
               {
                   request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
               }
               return response;
           });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreatedHttpResponse(request, () =>
           {
               HttpResponseMessage response = null;
               if (ModelState.IsValid)
               {
                   var listPostCategory = _postCategoryService.GetAll();
                   var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listPostCategory);

                   response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);
                   return response;
               }
               else
               {
                   request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                   return null;
               }
           });
        }
    }
}