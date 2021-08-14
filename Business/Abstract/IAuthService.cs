using Business.Jwt;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        bool Register(User user);
        bool Login(User user);
        AccessToken CreateAccessToken(User user);
        bool UserExist(string username);
    }
}
