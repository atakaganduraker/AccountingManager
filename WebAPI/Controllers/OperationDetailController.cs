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
    public class OperationDetailController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        IOperationDetailService _operationDetailService;

        public OperationDetailController(IOperationDetailService operationDetailService)
        {
            _operationDetailService = operationDetailService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddOperationDetail")]
        public IActionResult Add(OperationDetail operationDetail)
        {
            var result = _operationDetailService.Add(operationDetail);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteOperationDetail")]
        public IActionResult DeleteById(int id)
        {
            var result = _operationDetailService.DeleteById(id);

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
            var result = _operationDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("UptadeOperationDetail")]
        public IActionResult Uptade(OperationDetail operationDetail)
        {
            var result = _operationDetailService.Uptade(operationDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}