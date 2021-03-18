using O4Desk.Web.Api.Models.Companies;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;

namespace O4Desk.Web.Api.Tests.Unit.Services.Companies
{
    public partial class CompanyServiceTests
    {
        [Fact]
        public async Task ShouldCreateCompanyAsync()
        {
            // given
            DateTimeOffset randomDateTime = GetRandomDateTime();
            DateTimeOffset dateTime = randomDateTime;
            Company randomCompany = CreateRandomCompany(randomDateTime);
            randomCompany.UpdatedBy = randomCompany.CreatedBy;
            Company inputCompany = randomCompany;
            Company storageCompany = randomCompany;
            Company expectedCompany = storageCompany;

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
                    .Returns(dateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertCompanyAsync(inputCompany))
                    .ReturnsAsync(storageCompany);

            // when
            Company actualCompany =
                await this.companyService.CreateCompanyAsync(inputCompany);

            // then
            actualCompany.Should().BeEquivalentTo(expectedCompany);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCompanyAsync(inputCompany),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
