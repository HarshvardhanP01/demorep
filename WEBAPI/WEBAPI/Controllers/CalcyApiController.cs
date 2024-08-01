using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcyApiController : ControllerBase
    {
        [HttpGet()]
        [Route("Add/{a}/{b}")]
        //public int Add(int a, int b) => a + b;
        public IActionResult Add(int a, int b)
        {
            int res = 0;
            try
            {
                res = a + b;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpGet("CalculateSub/{a}/{b}")]
        public int Sub(int a, int b) => a - b;

    }
}
