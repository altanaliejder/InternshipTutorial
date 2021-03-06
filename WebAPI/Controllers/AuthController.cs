using Autofac;
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
    public class AuthController : BaseController
    {

        IAuthService _authService;

        public AuthController(ILifetimeScope currentContainer):base(currentContainer)
        {
            
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin)
            {
                return BadRequest("Loginde hata");
            }
            var result = _authService.CreateAccessToken(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Loginde hata");
        }



        [HttpPost("register")]
        public IActionResult Register(User user)
        {
           var result= this.currentContainer.Resolve<IUserBusiness>();
            var registeredUser = _authService.UserExist(user.Email);
            if (registeredUser)
            {
                return BadRequest("Böyle bir kullanıcı var");
            }

            var registerResult = _authService.Register(user);
            //var result = _authService.CreateAccessToken(user);

            if (registerResult )
            {
                return Ok(registerResult);
            }
            return BadRequest("Register hata");
        }
    }
}
