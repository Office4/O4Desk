﻿using O4Desk.Web.Api.Brokers.DateTime;
using O4Desk.Web.Api.Brokers.Logging;
using O4Desk.Web.Api.Brokers.Storage;
using O4Desk.Web.Api.Models.Companies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Services.Companies
{
    public class CompanyService : StandardService, ICompanyService
    {
        public CompanyService(IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker) : base(storageBroker, loggingBroker, dateTimeBroker)
        {

        }

        public async ValueTask<Company> RetrieveCompanyByIdAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> RetrieveAllCompanies()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Company> CreateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Company> RemoveCompanyByIdAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Company> ModifyCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}