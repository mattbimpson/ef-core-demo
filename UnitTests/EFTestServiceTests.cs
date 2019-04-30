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
                .UseInMemoryDatabase(databaseName: "Get_Employees")
                .Options;

            using (var context = new EmployeeContext(options))
            {
                DbInitialiser.Initialise(context);
                var service = new EFTestService(context);
                List<Employee> employees = service.GetEmployees().Result.ToList();
                Assert.AreEqual(3, employees.Count);
            }
        }

        [Test]
        public void CanAddEmployee()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "Add_Employee")
                .Options;

            const int NewEmplyeeId = 101;

            using (var context = new EmployeeContext(options))
            {
                DbInitialiser.Initialise(context);
                var service = new EFTestService(context);
                var employee = new Employee
                {
                    Id = NewEmplyeeId,
                    Firstname = "Mr",
                    Lastname = "Test",
                    Age = 99,
                    RoleId = 0
                };

                service.AddEmployee(employee);
                context.SaveChanges();
            }

            using (var context = new EmployeeContext(options))
            {
                var service = new EFTestService(context);
                var employee = service.GetEmployeeById(NewEmplyeeId).Result;
                Assert.That(employee, Is.Not.Null);
            }
        }
    }
}