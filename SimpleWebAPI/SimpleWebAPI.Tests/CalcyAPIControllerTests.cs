using SimpleWebAPI.Controllers;

namespace SimpleWebAPI.Tests
{
    public class CalcyAPIControllerTests
    {
        [Fact]
        public void AddTest()
        {
            CalcyAPIController controller = new CalcyAPIController();
            var Result = controller.Add(20,10);
            Assert.Equal(30, Result);
        }

        [Fact]
        public void MulTest()
        {
            CalcyAPIController controller = new CalcyAPIController();
            var Result = controller.Mul(20, 10);
            Assert.Equal(200, Result);
        }

        [Fact]
        public void DivTest()
        {
            CalcyAPIController controller = new CalcyAPIController();
            var Result = controller.Div(20, 10);
            Assert.Equal(2, Result);
          
        }

        [Fact]
        public void DivTestDivByZero()
        {
            CalcyAPIController controller = new CalcyAPIController();
            //var Result = controller.Div(20, 0);
            Assert.Throws<DivideByZeroException>(()=> controller.Div(20,0));

        }
    }
}