using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface ILogErrorService
    {
        LogError Add(LogError log);
        void Update(LogError log);
        LogError DeleteById(int Id);
        IEnumerable<LogError> GetAll();
        LogError GetById(int Id);

        void Save();
    }
    public class LogErrorService : ILogErrorService
    {
        ILogErrorRepository _logErrorRepository;
        IUnitOfWork _unitOfWork;

        public LogErrorService(ILogErrorRepository logError, IUnitOfWork unitOfWork)
        {
            this._logErrorRepository = logError;
            this._unitOfWork = unitOfWork;
        }


        public LogError Add(LogError log)
        {
            return _logErrorRepository.Add(log);
        }

        public LogError DeleteById(int Id)
        {
            return _logErrorRepository.DeleteByID(Id);
        }

        public IEnumerable<LogError> GetAll()
        {
            return _logErrorRepository.GetAll();
        }

        public LogError GetById(int Id)
        {
            return _logErrorRepository.GetSingleById(Id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LogError log)
        {
            _logErrorRepository.Update(log);
        }
    }
}
