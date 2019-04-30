using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class DbInitialiser
    {
        public static void Initialise(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee { Age = 21, Firstname = "Bob", Lastname = "Smith" },
                new Employee { Age = 46, Firstname = "Mr", Lastname = "Blobby" },
                new Employee { Age = 30, Firstname = "Jane", Lastname = "Doe" }
            };

            foreach(Employee e in employees)
            {
                context.Add(e);
            }

            context.SaveChanges();
        }
    }
}
