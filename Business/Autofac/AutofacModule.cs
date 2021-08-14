using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
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
            builder.RegisterType<UserBusiness>().As<IUserBusiness>().InstancePerLifetimeScope();
            builder.RegisterType<TestManager>().As<ITestService>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepositoryBase<User>>().As<IRepository<User>>().InstancePerLifetimeScope();


        }
    }
}
