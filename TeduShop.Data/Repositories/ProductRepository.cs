using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository: IReadOnlyCollection<Product>
    {

    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
