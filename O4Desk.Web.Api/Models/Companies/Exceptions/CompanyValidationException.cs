using System;

namespace O4Desk.Web.Api.Models.Companies.Exceptions
{
    public class CompanyValidationException : Exception
    {
        public CompanyValidationException(Exception innerException)
            : base("Invalid input, contact support.", innerException)
        { }
    }
}
