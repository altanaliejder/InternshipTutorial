using Autofac;
using Business.Abstract;
using Business.Jwt;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;

namespace Business.Concrete
{
    public class AuthManager : BaseBusiness,IAuthService
    {
        //IUserBusiness _userBusiness;
        //ITokenHelper _tokenHelper;

        public AuthManager(ILifetimeScope currentContainer):base(currentContainer)
        {
            //_userBusiness = userBusiness;
            //_tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var tokenHelper= this.currentContainer.Resolve<ITokenHelper>();
            var userBusiness = this.currentContainer.Resolve<IUserBusiness>();
            var claims = userBusiness.GetClaims(user);
            return tokenHelper.CreateToken(user, claims);
        }

        public bool Login(User user)
        {
            var loginUser=this.currentContainer.Resolve<IMapper>().Map<UserForLogin>(user);
            var registeredUser = this.currentContainer.Resolve<IUserBusiness>().GetByMail(loginUser.Email);
            if (registeredUser==null)
            {
                return false;
            }
            else if (registeredUser.Password != loginUser.Password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Register(User user)
        {
            var registerUser = this.currentContainer.Resolve<IMapper>().Map<UserForRegister>(user);
            this.currentContainer.Resolve<IUserBusiness>().Add(registerUser);
            return true;

        }

        public bool UserExist(string mail)
        {
            if (this.currentContainer.Resolve<IUserBusiness>().GetByMail(mail)!= null)
            {
                return true;
            }
            return false;
        }
    }
}
