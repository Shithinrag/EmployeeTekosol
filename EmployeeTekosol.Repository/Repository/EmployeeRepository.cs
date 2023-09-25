using Dapper;
using EmployeeTekosol.Repository.Abstraction;
using EmployeeTekosol.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTekosol.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _dapperContext;
        public EmployeeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateEmployee(Employee employee)
        {
            var query = "INSERT INTO EMPLOYEE (Name, DeptId, Gender, Salary, PhoneNo) VALUES (@Name,@DeptId,@Gender,@Salary,@PhoneNo)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("DeptId", employee.DeptId, DbType.String);
            parameters.Add("Gender", employee.Gender, DbType.String);
            parameters.Add("Salary", employee.Salary, DbType.Decimal);
            parameters.Add("PhoneNo", employee.PhoneNo, DbType.String);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int? id)
        {
            var query = "DELETE FROM EMPLOYEE WHERE EmployeeId = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }

        }

        public async Task<Employee> GetEmployee(int? id)
        {
            var query = "SELECT * FROM EMPLOYEE WHERE EmployeeId = @EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeId", id, DbType.Int64);
            using( var  connection = _dapperContext.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Employee>(query, parameters);
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM EMPLOYEE";
            using(var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Employee>(query);
                return companies.ToList();
            }
            throw new NotImplementedException();
        }

        public async Task UpdateEmployee(int? id, Employee employee)
        {
            var query = "UPDATE EMPLOYEE SET Name = @Name, DeptId = @DeptId, Gender = @Gender, Salary = @Salary, PhoneNo= @PhoneNo WHERE EmployeeId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int64);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("DeptId", employee.DeptId, DbType.String);
            parameters.Add("Gender", employee.Gender, DbType.String);
            parameters.Add("Salary", employee.Salary, DbType.Decimal);
            parameters.Add("PhoneNo", employee.PhoneNo, DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }


        }
    }
}
