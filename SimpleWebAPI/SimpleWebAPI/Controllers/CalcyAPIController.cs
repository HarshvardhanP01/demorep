using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcyAPIController : ControllerBase
    {
        [HttpGet("Add/{a}/{b}")]
        public double Add(int a, int b) => a + b;

        [HttpGet("Mul/{a}/{b}")]
        public double Mul(int a, int b) => a * b;

        [HttpGet("Div/{a}/{b}")]
        public double Div(int a, int b) {
            if (b == 0)
            {
                throw new DivideByZeroException("No 0 to B");
            }
            return a / b;
        }

    }
}
