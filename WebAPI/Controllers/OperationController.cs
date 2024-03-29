﻿using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Result.IResult;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddOperation")]
        public IActionResult Add(Operation operation)
        {
            var result = _operationService.Add(operation);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpDelete("DeleteOperation")]
        public IActionResult DeleteById(int  id)
        {
            var result = _operationService.DeleteById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //Dependency Chain---
            var result = _operationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            
                return BadRequest(result);
                                        
        }
        

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _operationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCompany")]
        public IActionResult GetByCompany(int companyId)
        {
            var result = _operationService.GetByCompanyId(companyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("UptadeOperation")]
        public IActionResult Uptade(Operation operation)
        {
            var result = _operationService.Uptade(operation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}