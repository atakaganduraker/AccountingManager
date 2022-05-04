﻿using Business.Abstract;
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

        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
        }

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
            throw new NotImplementedException();
        }

        public IDataResult<List<Operation>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Uptade(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
