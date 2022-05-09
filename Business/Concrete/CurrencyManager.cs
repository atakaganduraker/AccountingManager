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

        public IDataResult<List<Currency>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Currency>> GetById(int id)
        {
            throw new NotImplementedException();
        }

     

        public IResult Uptade(Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}
