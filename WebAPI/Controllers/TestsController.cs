using Business.Abstract;
using Entities;
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
        IUserBusiness _userBusiness;

        public TestsController(ITestService testService, IUserBusiness userBusiness)
        {
            _testService = testService;
            _userBusiness = userBusiness;
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

        [HttpGet("getbyusername")]
        public IActionResult GetByUsername(string username)
        {
            var result = _userBusiness.GetByUsername(username);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            _userBusiness.Add(user);
            return Ok();
        }
    }
}
