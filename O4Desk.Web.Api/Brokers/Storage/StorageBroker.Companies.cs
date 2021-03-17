using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using O4Desk.Web.Api.Models.Companies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Brokers.Storage
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        public DbSet<Company> Companies { get; set; }

        public async ValueTask<Company> InsertCompanyAsync(Company company)
        {
            EntityEntry<Company> companyEntityEntry = await this.Companies.AddAsync(company);
            await this.SaveChangesAsync();

            return companyEntityEntry.Entity;
        }
        public IQueryable<Company> SelectAllCompanies() => 
            this.Companies.AsQueryable();


        public ValueTask<Company> DeleteContactAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> SelectAllCompanies()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Company> SelectContactByIdAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Company> UpdateContactAsync(Company company)
        {
            throw new NotImplementedException();
        }

    }
}
