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
    public class OperationDetailManager : IOperationDetailService
    {

        IOperationDetailDal _operationDetailDal;

        public OperationDetailManager(IOperationDetailDal operationDetailDal)
        {
            _operationDetailDal = operationDetailDal;
        }

        public IResult Add(OperationDetail operationDetail)
        {
            _operationDetailDal.Add(operationDetail);
            return new SuccessResult("Bşarıyla eklendi");
        }

        public IResult Delete(OperationDetail operationDetail)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var operationDetail = _operationDetailDal.Get(o => o.Id == id);

            _operationDetailDal.Delete(operationDetail);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

    
        public IDataResult<List<OperationDetail>> GetAll()
        {
            return new SuccessDataResult<List<OperationDetail>>(_operationDetailDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<OperationDetail>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(OperationDetail operationDetail)
        {
            _operationDetailDal.Update(operationDetail);

            return new SuccessResult(operationDetail.Id + " Başarıyla Güncellendi ");
        }
    }
}
