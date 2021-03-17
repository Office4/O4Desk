﻿using EFxceptions;
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

        public async ValueTask<Company> SelectCompanyByIdAsync(Guid companyId)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await Companies.FindAsync(companyId);
        }

        public async ValueTask<Company> UpdateCompanyAsync(Company company)
        {
            EntityEntry<Company> companyEntityEntry = this.Companies.Update(company);
            await this.SaveChangesAsync();

            return companyEntityEntry.Entity;
        }

        public async ValueTask<Company> DeleteCompanyAsync(Company company)
        {
            EntityEntry<Company> companyEntityEntry = this.Companies.Remove(company);
            await this.SaveChangesAsync();

            return companyEntityEntry.Entity;
        }

    }
}
