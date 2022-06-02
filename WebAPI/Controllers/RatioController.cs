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
    public class RatioController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        IRatioService _ratioService;

        public RatioController(IRatioService ratioService)
        {
            _ratioService = ratioService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddRatio")]
        public IActionResult Add(Ratio ratio)
        {
            var result = _ratioService.Add(ratio);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteRatio")]
        public IActionResult DeleteById(int id)
        {
            var result = _ratioService.DeleteById(id);

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
            var result = _ratioService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("UptadeOperationType")]
        public IActionResult Uptade(Ratio ratio)
        {
            var result = _ratioService.Uptade(ratio);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}