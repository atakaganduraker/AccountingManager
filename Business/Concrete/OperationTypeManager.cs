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
    public class OperationTypeManager : IOperationTypeService
    {
        IOperationTypeDal _operationTypenDal;

        public OperationTypeManager(IOperationTypeDal operationTypenDal)
        {
            _operationTypenDal = operationTypenDal;
        }

        public IResult Add(OperationType operationType)
        {
            _operationTypenDal.Add(operationType);
            return new SuccessResult("");
        }

        public IResult Delete(OperationType operationType)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var operationType = _operationTypenDal.Get(o => o.Id == id);

            _operationTypenDal.Delete(operationType);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

        public IDataResult<List<OperationType>> GetAll()
        {
            return new SuccessDataResult<List<OperationType>>(_operationTypenDal.GetAll(), "OLDUU");

        }

        public IDataResult<List<OperationType>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(OperationType operationType)
        {
            _operationTypenDal.Update(operationType);

            return new SuccessResult(operationType.Id + " Başarıyla Güncellendi ");
        }
    }
}
