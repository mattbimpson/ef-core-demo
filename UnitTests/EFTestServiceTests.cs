using DataAccess;
using DataModels;
using EFServices;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class EFTestServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanRetrieveAllEmployees()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "Add_Employee")
                .Options;

            using (var context = new EmployeeContext(options))
            {
                DbInitialiser.Initialise(context);
                var service = new EFTestService(context);
                List<Employee> employees = service.GetEmployees().Result.ToList();
                Assert.AreEqual(3, employees.Count);
            }
        }
    }
}