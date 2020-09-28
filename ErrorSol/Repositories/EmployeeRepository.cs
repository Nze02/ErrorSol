using ErrorSol.Contracts;
using ErrorSol.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Id)
            .ToListAsync();

        public async Task<Employee> GetEmployeeAsync(Guid Id, bool trackchanges) =>
            await FindByCondition(e => e.Id.Equals(Id), trackchanges)
            .SingleOrDefaultAsync();

        public void CreateEmployee(Employee Employee) => Create(Employee);

        public void DeleteEmployee(Employee Employee) => Delete(Employee);
    }
}
