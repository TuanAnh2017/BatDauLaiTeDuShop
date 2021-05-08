using System;

namespace TeduShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory // Kế thừa từ 1 Interface và 1 Abtract class thì được
        // Chứ 2 Abstract class thì không được
    {
        // IDbFactory là 1 cái giao tiếp để khởi tạo đối tượng Entity, chúng ta không khởi tạo trực tiếp
        // Mà thông qua cái Factory

            // DbFacTory dùng để khởi tạo DBContext thay vì new trực tiếp

        TeduShopDbContext dbcontext;
        public TeduShopDbContext Init() // Phương thức này sẽ khởi tạo đối tượng cho DbContext
        {
            return dbcontext ?? (dbcontext = new TeduShopDbContext());
            // Nếu dbcontext == null thì nó sẽ khởi tạo 1 new TeduShopDbContext()
        }

        protected override void DisposeCore()
        {
            if (dbcontext==null)
            {
                dbcontext.Dispose();
            }
        }
    }
}