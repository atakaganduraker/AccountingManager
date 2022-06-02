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
    public class CurrencyManager : ICurrencyService
    {

        ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }

        public IResult Add(Currency currency)
        {
            _currencyDal.Add(currency);
            string id = currency.Id.ToString();
            return new SuccessResult(id + "Başarıyla eklendi");
        }

        public IResult Delete(Currency currency)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var currency = _currencyDal.Get(o => o.Id == id);

            _currencyDal.Delete(currency);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

        public IDataResult<List<Currency>> GetAll()
        {
            return new SuccessDataResult<List<Currency>>(_currencyDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<Currency>> GetById(int id)
        {
            throw new NotImplementedException();
        }

     

        public IResult Uptade(Currency currency)
        {
            _currencyDal.Update(currency);

            return new SuccessResult(currency.Id + " Başarıyla Güncellendi ");
        }
    }
}
