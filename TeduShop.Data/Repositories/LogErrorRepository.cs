using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface ILogErrorRepository : IRepository<LogError>
    {

    }
    public class LogErrorRepository : RepositoryBase<LogError>, ILogErrorRepository
    {
        public LogErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
