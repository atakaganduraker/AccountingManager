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
    public class CompanyManager : ICompanyService
    {

        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            string id = company.CompanyName.ToString();
            return new SuccessResult(id + " Başarıyla eklendi");
        }

        public IResult Delete(Company company)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            var company = _companyDal.Get(o => o.Id == id);

            _companyDal.Delete(company);
            return new SuccessResult(id + "Numaralı Şirket Başarıyla silindi ");
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(), "OLDUU");
        }

        public IDataResult<List<Company>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(Company company)
        {
            _companyDal.Update(company);

            return new SuccessResult(company.Id + " Başarıyla Güncellendi ");
        }
    }
}
