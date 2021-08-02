using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestManager : ITestService
    {
        public string HelloWorld()
        {
            return "Hello world";
        }

        public string TestMethod()
        {
            return "This is a test method";
        }
    }
}
