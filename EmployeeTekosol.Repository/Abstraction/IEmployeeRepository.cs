using EmployeeTekosol.Repository.Models;

namespace EmployeeTekosol.Repository.Abstraction
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int? id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(int? id, Employee employee);
        Task DeleteEmployee(int? id);
    }
}
