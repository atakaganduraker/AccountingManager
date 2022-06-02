using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICurrencyService
    {
        IDataResult<List<Currency>> GetAll();
        IDataResult<List<Currency>> GetById(int id);
        IResult Add(Currency currency);
        IResult Delete(Currency currency);
        IResult Uptade(Currency currency);
        IResult DeleteById(int id);

    }
}

