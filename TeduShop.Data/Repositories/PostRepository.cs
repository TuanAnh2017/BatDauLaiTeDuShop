using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetMultiPaging(object p, int totalRow, int page, int pagesize);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}