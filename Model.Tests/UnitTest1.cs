using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
namespace Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (SmartParkContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        private static SmartParkContext GetContext()
        {
            return new SmartParkContext();
        }

        [TestMethod]
        public void CanGetCustomers()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(3, context.Users.ToList().Count);
            }
        }
    }
}
