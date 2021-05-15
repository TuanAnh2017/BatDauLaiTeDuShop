using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategory;
        private ILogErrorService _logError;
        public PostCategoryController(ILogErrorService logError, IPostCategoryService postCategory) : base(logError)
        {
            this._logError = logError;
            this._postCategory = postCategory;
        }

       
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreatedHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var Category = _postCategory.Add(postCategory);
                    _postCategory.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, Category);
                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreatedHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategory.Update(postCategory);
                    _postCategory.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
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
                   request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
               }
               else
               {
                   _postCategory.DeleteByID(Id);
                   _postCategory.Save();

                   response = request.CreateResponse(HttpStatusCode.OK);
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
                   request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
               }
               else
               {
                   var listCategory = _postCategory.GetAll();
                   response = request.CreateErrorResponse(HttpStatusCode.OK, listCategory);
               }

               return response;
           });
        }

    }
}
