using EmployeeTekosol.Repository.Abstraction;
using EmployeeTekosol.Repository.Models;
using EmployeeTekosol.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTekosol.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }       

        public async Task CreateEmployee(Employee employee)
        {
            await _employeeRepository.CreateEmployee(employee);
        }

        public async Task DeleteEmployee(int? id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<Employee> GetEmployee(int? id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task UpdateEmployee(int? id, Employee employee)
        {
            await _employeeRepository.UpdateEmployee(id, employee);
        }
    }
}
