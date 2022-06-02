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
    public class CaseManager : ICaseService
    {
        ICaseDal _caseDal;

        public CaseManager(ICaseDal caseDal)
        {
            _caseDal = caseDal;
        }

        public IResult Add(Case casee)
        {
            _caseDal.Add(casee);
            string id = casee.Id.ToString();
            return new SuccessResult(id + " Başarıyla eklinde ");
        }

       
        public IResult Delete(Case casee)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            Case casee = _caseDal.Get(o => o.Id == id);

            _caseDal.Delete(casee);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

        public IResult DeleteById(Case casee)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Case>> GetAll()
        {
            return new SuccessDataResult<List<Case>>(_caseDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<Case>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(Case casee)
        {


            _caseDal.Update(casee);

            return new SuccessResult(casee.Id + " Başarıyla Güncellendi ");
        }

        


        //IDataResult<List<Case>> ICaseService.GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
