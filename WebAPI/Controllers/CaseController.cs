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
    public class CaseController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddCase")]
        public IActionResult Add(Case casee)
        {
            var result = _caseService.Add(casee);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCase")]
        public IActionResult DeleteById(int id)
        {
            var result = _caseService.DeleteById(id);

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
            var result = _caseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("UptadeCase")]
        public IActionResult Uptade(Case casee)
        {
            var result = _caseService.Uptade(casee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}