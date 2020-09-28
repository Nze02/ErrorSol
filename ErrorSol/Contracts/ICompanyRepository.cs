using ErrorSol.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorSol.Contracts
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompanyAsync(Guid Id, bool trackchanges);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
