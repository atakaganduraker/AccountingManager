using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {

        IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
            {
                //Dependency chain--
                //IProductService productService = new ProductManager(new EfProductDal());
                Thread.Sleep(1000);
                var result = _operationService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }


        [HttpPost("add")]
        public IActionResult Add(Operation operation)
        {

            var result = _operationService.Add(operation);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
