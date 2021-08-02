using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("gettestmethod")]
        public string GetTestMethod()
        {
            return _testService.TestMethod();
        }

        [HttpGet("gethelloworld")]
        public string GetHelloWorld()
        {
            return _testService.HelloWorld();
        }
    }
}
