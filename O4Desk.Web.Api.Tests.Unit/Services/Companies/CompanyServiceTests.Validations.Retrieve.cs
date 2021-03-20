using Moq;
using O4Desk.Web.Api.Models.Companies;
using O4Desk.Web.Api.Models.Companies.Exceptions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace O4Desk.Web.Api.Tests.Unit.Services.Companies
{
    public partial class CompanyServiceTests
    {
        [Fact]
        public async void ShouldThrowValidationExceptionOnRetrieveWhenStorageCompanyIsNullAndLogItAsync()
        {
            // given
            Guid randomCompanyId = Guid.NewGuid();
            Guid inputCompanyId = randomCompanyId;
            Company invalidStorageCompany = null;
            var notFoundCompanyException = new NotFoundCompanyException(inputCompanyId);

            var expectedCompanyValidationException =
                new CompanyValidationException(notFoundCompanyException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectCompanyByIdAsync(inputCompanyId))
                    .ReturnsAsync(invalidStorageCompany);

            // when
            ValueTask<Company> retrieveCompanyByIdTask =
                this.companyService.RetrieveCompanyByIdAsync(inputCompanyId);

            // then
            await Assert.ThrowsAsync<CompanyValidationException>(() =>
                retrieveCompanyByIdTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedCompanyValidationException))),
                    Times.Once);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Never);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectCompanyByIdAsync(inputCompanyId),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}
