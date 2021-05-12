using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _unit;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]

        public void Initiallize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _unit = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _unit.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory { ID = 1, Name = "Test nhé 1", Alias = "Alias1",Status = true  },
                new PostCategory {ID = 2, Name = "Test nhé 2",Alias = "Alias2",Status = true  },
                new PostCategory {ID = 3, Name = "Test nhé 3", Alias = "Alias3", Status = true  }
            };


        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            // Set up method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            // Call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);


        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();

            postCategory.Name = "Test nhé3";
            postCategory.Alias = "alias";
            postCategory.Status = true;

            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            }); // Ở đây chúng ta setup có nghĩa chúng ta cài đặt cho cái đối tượng Mock của Repository trả về đúng Id = 1


            var result = _categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

       
    }
}