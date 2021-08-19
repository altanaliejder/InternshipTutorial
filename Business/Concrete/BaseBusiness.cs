using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseBusiness
    {
         protected readonly ILifetimeScope currentContainer;

        public BaseBusiness(ILifetimeScope currentContainer)
        {
            this.currentContainer = currentContainer;
        }
    }
}
