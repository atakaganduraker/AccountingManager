using Business.Abstract;
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
    public class OperationTypeController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        IOperationTypeService _operationTypeService;

        public OperationTypeController(IOperationTypeService operationTypeService)
        {
            _operationTypeService = operationTypeService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddDeleteOperationType")]
        public IActionResult Add(OperationType operationType)
        {
            var result = _operationTypeService.Add(operationType);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteOperationType")]
        public IActionResult DeleteById(int id)
        {
            var result = _operationTypeService.DeleteById(id);

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
            var result = _operationTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("UptadeOperationType")]
        public IActionResult Uptade(OperationType operationType)
        {
            var result = _operationTypeService.Uptade(operationType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}