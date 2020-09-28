using ErrorSol.Contracts;
using ErrorSol.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(e => e.Id)
            .ToListAsync();

        public async Task<Company> GetCompanyAsync(Guid Id, bool trackchanges) =>
            await FindByCondition(e => e.Id.Equals(Id), trackchanges)
            .SingleOrDefaultAsync();

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);
    }
}
