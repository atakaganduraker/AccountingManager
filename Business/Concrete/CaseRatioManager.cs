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
    public class CaseRatioManager : ICaseRatioService
    {
        ICaseRatioDal _caseRatioDal;

        public CaseRatioManager(ICaseRatioDal caseRatioDal)
        {
            _caseRatioDal = caseRatioDal;
        }

        public IResult Add(CaseRatio caseRatio)
        {
            _caseRatioDal.Add(caseRatio);
            string id = caseRatio.Id.ToString();
            return new SuccessResult(id +"Başarıyla Eklendi");
        }

        public IResult Delete(CaseRatio caseRatio)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            CaseRatio caseRatio = _caseRatioDal.Get(o => o.Id == id);

            _caseRatioDal.Delete(caseRatio);
            return new SuccessResult(id + "Numaralı caseRatio Başarıyla silindi ");
        }

        public IDataResult<List<CaseRatio>> GetAll()
        {
            return new SuccessDataResult<List<CaseRatio>>(_caseRatioDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<CaseRatio>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(CaseRatio caseRatio)
        {
            _caseRatioDal.Update(caseRatio);

            return new SuccessResult(caseRatio.Id + " Başarıyla Güncellendi ");
        }
    }
}
