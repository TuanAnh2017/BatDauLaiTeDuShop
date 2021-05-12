using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Linq;

namespace TeduShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status == true
                        orderby p.CreatedDate descending 
                        select p;
            // Đầu tiên chúng ta xây dựng cái query lấy theo cái tag

            totalRow = query.Count(); // => Lấy tổng số dòng của 2 bảng làm nhiệm vụ phân trang
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //query chúng ta sẽ skip. VD trang số 1 = (1-1)*20 .take 20 => Lấy từ vị trí số 0 đến 20
                                    // trang số 2 = (2-1)*20 .take 20 => Lấy từ vị trí số 20 lại take thêm 20 bản ghi nữa
            return query;
        }
    }
}