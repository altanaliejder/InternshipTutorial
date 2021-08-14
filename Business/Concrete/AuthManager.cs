using Business.Abstract;
using Business.Jwt;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserBusiness _userBusiness;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserBusiness userBusiness, ITokenHelper tokenHelper)
        {
            _userBusiness = userBusiness;
            _tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userBusiness.GetClaims(user);
            return _tokenHelper.CreateToken(user,claims);
        }

        public bool Login(User user)
        {
            var registeredUser = _userBusiness.GetByMail(user.Email);
            if (registeredUser==null)
            {
                return false;
            }
            else if (registeredUser.Password != user.Password)
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
            _userBusiness.Add(user);
            return true;

        }

        public bool UserExist(string username)
        {
            if (_userBusiness.GetByMail(username) != null)
            {
                return true;
            }
            return false;
        }
    }
}
