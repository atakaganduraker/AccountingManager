using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _operationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }
}