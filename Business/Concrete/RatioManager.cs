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
    public class RatioManager : IRatioService
    {
        IRatioDal _ratioDal;

        public RatioManager(IRatioDal ratioDal)
        {
            _ratioDal = ratioDal;
        }

        public IResult Add(Ratio ratio)
        {
            _ratioDal.Add(ratio);
            return new  SuccessResult("");
        }

        public IResult Delete(Ratio ratio)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var ratio = _ratioDal.Get(o => o.Id == id);

            _ratioDal.Delete(ratio);
            return new SuccessResult(id + " Başarıyla silindi ");
        }

        public IDataResult<List<Ratio>> GetAll()
        {
            return new SuccessDataResult<List<Ratio>>(_ratioDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<Ratio>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(Ratio ratio)
        {
            _ratioDal.Update(ratio);

            return new SuccessResult(ratio.Id + " Başarıyla Güncellendi ");
        }
    }
}
