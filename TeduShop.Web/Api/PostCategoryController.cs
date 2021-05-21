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
            //this._logError = logError;
            this._postCategory = postCategory;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreatedHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var Category = _postCategory.Add(postCategory);
                    _postCategory.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, Category);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
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
                    _postCategory.Update(postCategory);
                    _postCategory.Save();

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
                   _postCategory.DeleteByID(Id);
                   _postCategory.Save();

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
                   var listCategory = _postCategory.GetAll();
                   response = request.CreateResponse(HttpStatusCode.OK, listCategory);
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