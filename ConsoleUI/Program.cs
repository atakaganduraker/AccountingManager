﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{                                                                                   
    internal class Program
    {
        static void Main(string[] args)
        {
            //OperationManager operationManager = new OperationManager(new EfOperationDal());

            //Operation operation = new Operation() {OperationId=1, CustomerName = "Ugir", Price = 100,};

            //CaseManager casemanager = new CaseManager(new EfCaseDal());

            //operationManager.Add(operation);

            //OperationTypeManager operationTypeManager = new OperationTypeManager(new EfOperationTypeDal());

            //OperationType operationType = new OperationType() { OperationTypeId=1,TypeName="FTD"};

            //operationTypeManager.Add(operationType);
            var date = DateTime.Now;


            //OperationManager operationManager = new OperationManager(new EfOperationDal());
            //Operation operation = new Operation() { CustomerName="test22",Price=1150, OperationTime = date,Commission=1502,Net=156,CompanyId=2,CurrencyId=1,IsActive=true,OperationDetailId=2,OperationTypeId=2};

            //Console.WriteLine(operationManager.Add(operation).Message);
            //var message = operationManager.Add(operation);

            //Console.WriteLine(message.Message);

            OperationManager companyManager = new OperationManager(new EfOperationDal());
            
            Operation company = new Operation()
            {
                
                CustomerName="test1",
                Commission=152,
                Net=2,
                OperationNote="Test",
                Price  =1,
                IsActive=true,
                OperationTypeId=1,
                OperationTime=date,
                CurrencyId = 1,
                OperationDetailId = 1,
                CompanyId = 1

            };
            var message = companyManager.Add(company);

            Console.WriteLine(message.Message+"23");

        }
    }
}
