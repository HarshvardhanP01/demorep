using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using WEBAPI.Controllers;
using WEBAPI.Data;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Tests
{
    public class DeptCOntrollerTest
    {
        private readonly CompanyDbContext _companyDbContext;
        private readonly DeptsApiController _deptsApiController;

        //Test Setup

        public DeptCOntrollerTest()
        {
            _companyDbContext = new CompanyDbContext(new DbContextOptions<CompanyDbContext>());
            _deptsApiController=new DeptsApiController(_companyDbContext);
        }

        [Fact]
        public async Task GetDeptsTests()
        {
            //Execute
            var actionResult=await _deptsApiController.GetDepartments();
            var objResult = actionResult.Value;
            Assert.IsAssignableFrom<IEnumerable<Dept>>(objResult);
        }


      /*  [Fact]
        public async Task GetDeptByIdTests()
        {
            //Execute
            var actionResult = await _deptsApiController.GetDepartments();
            var objResult = actionResult.Value;
            Assert.IsAssignableFrom<IEnumerable<Dept>>(objResult);
        }
*/

        [Fact]
        public async Task GetDeptForExistingTests()
        {
            //Execute
            var actionResult = await _deptsApiController.GetDept(0);
            var objResult = actionResult.Value;
            Assert.IsType<Dept>(objResult);
        }


        [Fact]
        public async Task GetDeptForNonExistingTests()
        {
            //Execute
            var actionResult = await _deptsApiController.GetDept(10);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}