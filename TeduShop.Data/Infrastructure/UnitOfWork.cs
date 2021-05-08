namespace TeduShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TeduShopDbContext dbcontext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TeduShopDbContext DbContext
        {
            get { return dbcontext ?? (dbcontext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChangesAsync();
        }
    }
}