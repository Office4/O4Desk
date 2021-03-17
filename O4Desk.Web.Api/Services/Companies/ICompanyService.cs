using O4Desk.Web.Api.Models.Companies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Services.Companies
{
    public interface ICompanyService
    {
        ValueTask<Company> RetrieveCompanyByIdAsync(Guid companyId);
        IQueryable<Company> RetrieveAllCompanies();
        ValueTask<Company> CreateCompanyAsync(Company company);
        ValueTask<Company> RemoveCompanyByIdAsync(Guid companyId);
        ValueTask<Company> ModifyCompanyAsync(Company company);

    }
}
