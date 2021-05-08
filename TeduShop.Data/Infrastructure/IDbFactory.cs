using System;

namespace TeduShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        // IDbFactory là 1 cái giao tiếp để khởi tạo đối tượng Entity, chúng ta không khởi tạo trực tiếp
        // Mà thông qua cái Factory
        TeduShopDbContext Init(); // Init cái DBContext
    }
}