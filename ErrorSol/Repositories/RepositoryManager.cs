using ErrorSol.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _db;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (companyRepository == null) 
                {
                    companyRepository = new CompanyRepository(_db);
                }

                return companyRepository;
            }
                
        }

        public IEmployeeRepository Employee 
        {
            get
            {
                if(employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(_db);
                }

                return employeeRepository;
            }
        }
        public Task SaveAsync() => _db.SaveChangesAsync();

    }
}
