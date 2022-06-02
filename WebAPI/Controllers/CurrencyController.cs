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
    public class CurrencyController : ControllerBase
    {
        //Loosely coupled
        //naming convention

        // IOperationService _operationService;
        ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        // [ValidationAspect(typeof(ProductValidator))]
        // [CacheRemoveAspect("IOperationService.Get")] // Db ye  yeni bir ekleme yaptığımızda gidip hazır olan Cacheleri siliyor eski data gelmesin diye.
        [HttpPost("AddCurrency")]
        public IActionResult Add(Currency currency)
        {
            var result = _currencyService.Add(currency);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteCompany")]
        public IActionResult DeleteById(int id)
        {
            var result = _currencyService.DeleteById(id);

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
            var result = _currencyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("UptadeCurrency")]
        public IActionResult Uptade(Currency currency)
        {
            var result = _currencyService.Uptade(currency);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}