using DataAccess;
using DataModels;
using EFServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFServices
{
    public class EFTestService : IEFTestService
    {
        private readonly EmployeeContext _context;

        public EFTestService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
