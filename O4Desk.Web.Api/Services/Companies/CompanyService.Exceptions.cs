using O4Desk.Web.Api.Models.Companies;
using O4Desk.Web.Api.Models.Companies.Exceptions;
using System;
using System.Threading.Tasks;

namespace O4Desk.Web.Api.Services.Companies
{
    public partial class CompanyService : StandardService, ICompanyService
    {
        private delegate ValueTask<Company> ReturningCompanyFunction();

        private async ValueTask<Company> TryCatch(ReturningCompanyFunction returningCopmanyFunction)
        {
            try
            {
                return await returningCopmanyFunction();
            }
            catch (NullCompanyException nullCompanyException)
            {
                throw CreateAndLogValidationException(nullCompanyException);
            }
            catch (NotFoundCompanyException notFoundCompanyException)
            {
                throw CreateAndLogValidationException(notFoundCompanyException);
            }

        }

        private CompanyValidationException CreateAndLogValidationException(Exception exception)
        {
            var companyValidationException = new CompanyValidationException(exception);
            this.loggingBroker.LogError(companyValidationException);

            return companyValidationException;
        }
    }
}
