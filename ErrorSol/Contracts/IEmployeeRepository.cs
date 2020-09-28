using ErrorSol.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid Id, bool trackchanges);
        void CreateEmployee(Employee Employee);
        void DeleteEmployee(Employee Employee);
    }
}
