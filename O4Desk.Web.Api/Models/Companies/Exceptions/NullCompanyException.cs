using System;

namespace O4Desk.Web.Api.Models.Companies.Exceptions
{
    public class NullCompanyException : Exception
    {
        public NullCompanyException() : base("The company is null.") { }
    }
}
