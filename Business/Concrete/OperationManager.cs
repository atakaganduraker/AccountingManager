using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class OperationManager : IOperationService
    {
        IOperationDal _operationDal;
        IOperationTypeService _operationTypeService;
        ICurrencyService _currencyService;
        IOperationDetailService _operationDetailService;
        ICompanyService _companyService;

        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
            //_operationTypeService = operationTypeService;
            //_currencyService = currencyService;
            //_companyService = companyService;
        }
        [ValidationAspect(typeof(OperationValidator))]
        [CacheRemoveAspect("IOperationService.Get")]
        public IResult Add(Operation operation)
        {

            _operationDal.Add(operation);
            string id = operation.Id.ToString();
            return new SuccessResult(id + " Başarıyla eklinde ");
        }
        public IResult Delete(Operation operation)
        {
               _operationDal.Delete(operation);
            string id = operation.Id.ToString();

            return new SuccessResult(id + " Başarıyla silindi ");
        }
        public IResult DeleteById(int id)
        {
            var entity = _operationDal.Get(o => o.Id == id);

            _operationDal.Delete(entity);
            return new SuccessResult(id + " Başarıyla silindi ");

        }

        public IDataResult<List<Operation>> GetAll()
        {
            return new SuccessDataResult<List<Operation>>(_operationDal.GetAll(),"OLDUU");
        }
        public IDataResult<List<Operation>> GetAllByCompanyId(int id)
        {
            return new SuccessDataResult<List<Operation>>(_operationDal.GetAll(p => p.CompanyId == id));
        }


        [CacheAspect]
        public IDataResult<Operation> GetById(int id)
        {
            return new SuccessDataResult<Operation>(_operationDal.Get(x => x.Id == id));

        }


        public IResult Uptade(Operation operation)
        {
            throw new NotImplementedException();
        }

     
    }
}
