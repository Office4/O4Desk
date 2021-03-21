using O4Desk.Web.Api.Models.Companies;
using O4Desk.Web.Api.Models.Companies.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Services.Companies
{
    public partial class CompanyService
   {
        private static void ValidateCompanyId(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new InvalidCompanyException(
                    parameterName: nameof(Company.Id),
                    parameterValue: companyId);
            }
        }

        private static void ValidateStorageCompany(Company storageCompany, Guid companyId)
        {
            if (storageCompany == null)
            {
                throw new NotFoundCompanyException(companyId);
            }
        }
    }
}
