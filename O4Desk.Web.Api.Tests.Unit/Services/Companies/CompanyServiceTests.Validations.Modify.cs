using Moq;
using O4Desk.Web.Api.Models.Companies;
using O4Desk.Web.Api.Models.Companies.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace O4Desk.Web.Api.Tests.Unit.Services.Companies
{
    public partial class CompanyServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnModifyWhenCompanyIsNullAndLogItAsync()
        {
            // given
            Company inValidCompany = null;
            var nullCompanyException = new NullCompanyException();
            var expectedCompanyValidationException =
                new CompanyValidationException(nullCompanyException);

            // when
            ValueTask<Company> modifyCompanyTask =
                this.companyService.ModifyCompanyAsync(inValidCompany);

            // then
            await Assert.ThrowsAsync<CompanyValidationException>(() =>
                modifyCompanyTask.AsTask());
            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedCompanyValidationException))),
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}
