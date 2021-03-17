using O4Desk.Web.Api.Models.Companies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Brokers.Storage
{
    public partial interface IStorageBroker
    {
        public ValueTask<Company> InsertCompanyAsync(Company company);
        public IQueryable<Company> SelectAllCompanies();
        public ValueTask<Company> SelectCompanyByIdAsync(Guid companyId);
        public ValueTask<Company> UpdateContactAsync(Company company);
        public ValueTask<Company> DeleteContactAsync(Company company);

    }
}
