using DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFServices.Interfaces
{
    public interface IEFTestService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task AddEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<Employee> GetEmployeeById(int id);
    }
}
