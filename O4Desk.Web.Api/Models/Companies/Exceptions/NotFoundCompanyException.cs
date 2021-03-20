using System;

namespace O4Desk.Web.Api.Models.Companies.Exceptions
{
    public class NotFoundCompanyException : Exception
    {
        public NotFoundCompanyException(Guid companyId)
            : base($"Couldn't find company with Id: {companyId}.")
        { }
    }
}
