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
    public class CaseRatioController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        ICaseRatioService _caseRatioService;

        public CaseRatioController(ICaseRatioService caseRatioService)
        {
            _caseRatioService = caseRatioService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddCaseRatio")]
        public IActionResult Add(CaseRatio caseRatio)
        {
            var result = _caseRatioService.Add(caseRatio);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCaseRatio")]
        public IActionResult DeleteById(int id)
        {
            var result = _caseRatioService.DeleteById(id);

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
            var result = _caseRatioService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("UptadeCaseRatio")]
        public IActionResult Uptade(CaseRatio caseRatio)
        {
            var result = _caseRatioService.Uptade(caseRatio);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}