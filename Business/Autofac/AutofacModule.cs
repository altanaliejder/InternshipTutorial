using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Autofac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserBusiness>().As<IUserBusiness>();
            builder.RegisterType<TestManager>().As<ITestService>(); 
            builder.RegisterGeneric(typeof(EfRepositoryBase<>)).As(typeof(IRepository<>));
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

        }
    }
}
