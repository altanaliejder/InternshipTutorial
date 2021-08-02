using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
