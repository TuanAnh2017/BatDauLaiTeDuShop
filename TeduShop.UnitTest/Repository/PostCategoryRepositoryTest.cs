using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.Repository
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initiallize()
        {
            dbFactory = new DbFactory();
            _postCategoryRepository = new PostCategoryRepository(dbFactory);
            _unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test nhé";
            postCategory.Alias = "alias";
            postCategory.Status = true;

            var result = _postCategoryRepository.Add(postCategory);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result.ID); // So sánh giá trị ngang bằng
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = _postCategoryRepository.GetAll().ToList();
            Assert.AreEqual(6, list.Count());
        }

        [TestMethod]
        public void PostCategory_Repository_Delete()
        {

            _postCategoryRepository.DeleteByID(9);
            _unitOfWork.Commit();


            var result2 = _postCategoryRepository.GetSingleById(9);
            Assert.IsNull(result2);

            //Assert.AreEqual(5, result.ID);
        }


    }
}