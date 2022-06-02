using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationCaseManager : IOperationCaseService
    {

        IOperationCaseDal _operationCaseDal ;

        public OperationCaseManager(IOperationCaseDal operationCaseDal)
        {
            _operationCaseDal = operationCaseDal;
        }

        public IResult Add(OperationCase operationCase)
        {
            _operationCaseDal.Add(operationCase);
            string id =operationCase.Id.ToString();
            return new SuccessResult(id);
        }

        public IResult Delete(OperationCase operationCase)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var operationCase = _operationCaseDal.Get(o => o.Id == id);

            _operationCaseDal.Delete(operationCase);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

        public IDataResult<List<OperationCase>> GetAll()
        {
            return new SuccessDataResult<List<OperationCase>>(_operationCaseDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<OperationCase>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(OperationCase operationCase)
        {
            throw new NotImplementedException();
        }
    }
}
