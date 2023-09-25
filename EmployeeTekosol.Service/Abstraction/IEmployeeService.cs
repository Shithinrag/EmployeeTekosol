using EmployeeTekosol.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTekosol.Service.Abstraction
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int? id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(int? id, Employee employee);
        Task DeleteEmployee(int? id);
    }
}
