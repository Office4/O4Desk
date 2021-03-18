using O4Desk.Web.Api.Models.Companies;
using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using Force.DeepCloner;

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

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCompanyAsync(inputCompany),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldModifyCompanyAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomDays = randomNumber;
            DateTimeOffset randomDate = GetRandomDateTime();
            Company randomCompany = CreateRandomCompany();
            Company inputCompany = randomCompany;
            Company afterUpdateStorageCompany = inputCompany;
            Company expectedCompany = afterUpdateStorageCompany;
            Company beforeUpdateStorageCompany = randomCompany.DeepClone();
            inputCompany.UpdatedDate = randomDate;
            Guid companyId = inputCompany.Id;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectCompanyByIdAsync(companyId))
                    .ReturnsAsync(beforeUpdateStorageCompany);

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
                    .Returns(randomDate);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateCompanyAsync(inputCompany))
                    .ReturnsAsync(afterUpdateStorageCompany);

            // when
            Company actualCompany = await this.companyService.ModifyCompanyAsync(inputCompany);

            // then
            actualCompany.Should().BeEquivalentTo(expectedCompany);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectCompanyByIdAsync(companyId),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateCompanyAsync(inputCompany),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRetrieveCompanyByIdAsync()
        {
            // given
            Guid randomCompanyId = Guid.NewGuid();
            Guid inputCompanyId = randomCompanyId;
            DateTimeOffset randomDateTime = GetRandomDateTime();
            Company randomCompany = CreateRandomCompany(randomDateTime);
            Company storageCompany = randomCompany;
            Company expectedCompany = storageCompany;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectCompanyByIdAsync(inputCompanyId))
                    .ReturnsAsync(storageCompany);

            // when
            Company actualCompany =
                await this.companyService.RetrieveCompanyByIdAsync(inputCompanyId);

            // then
            actualCompany.Should().BeEquivalentTo(expectedCompany);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Never);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectCompanyByIdAsync(inputCompanyId),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
