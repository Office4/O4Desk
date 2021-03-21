using System;

namespace O4Desk.Web.Api.Models.Companies.Exceptions
{
    public class InvalidCompanyException : Exception
    {
        public InvalidCompanyException(string parameterName, object parameterValue)
            : base($"Invalid Company, " +
                  $"ParameterName: {parameterName}, " +
                  $"ParameterValue: {parameterValue}.")
        { }
    }

}
