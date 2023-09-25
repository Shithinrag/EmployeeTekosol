using EmployeeTekosol.Repository.Models;
using EmployeeTekosol.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTekosol.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost, Route(nameof(CreateEmployee))]
        public async Task CreateEmployee(Employee employee)
        {
            await _employeeService.CreateEmployee(employee);
        }

        [HttpPost, Route(nameof(UpdateEmployee))]
        public async Task UpdateEmployee(int? id,Employee employee)
        {
            await _employeeService.UpdateEmployee(id, employee);
        }

        [HttpPost, Route(nameof(DeleteEmployee))]
        public async Task DeleteEmployee(int? id)
        {
            await _employeeService.DeleteEmployee(id);
        }

        [HttpGet,Route(nameof(GetEmployees))]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpGet, Route(nameof(GetEmployeeById))]        
        public async Task<Employee> GetEmployeeById(int? id)
        {
            return await _employeeService.GetEmployee(id);
        }
    }
}
