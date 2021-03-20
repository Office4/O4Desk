using Moq;
using O4Desk.Web.Api.Brokers.DateTime;
using O4Desk.Web.Api.Brokers.Logging;
using O4Desk.Web.Api.Brokers.Storage;
using O4Desk.Web.Api.Models.Companies;
using O4Desk.Web.Api.Services.Companies;
using System;
using System.Linq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace O4Desk.Web.Api.Tests.Unit.Services.Companies
{
    public partial class CompanyServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;

        private readonly ICompanyService companyService;

        public CompanyServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.companyService = new CompanyService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }

        private Company CreateRandomCompany() =>
            CreateCompanyFiller(dates: DateTimeOffset.UtcNow).Create();

        private Company CreateRandomCompany(DateTimeOffset dates) =>
            CreateCompanyFiller(dates).Create();

        private static Filler<Company> CreateCompanyFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Company>();
            Guid createdById = Guid.NewGuid();

            filler.Setup()
                .OnProperty(company => company.CreatedDate).Use(dates)
                .OnProperty(company => company.UpdatedDate).Use(dates)
                .OnProperty(company => company.CreatedBy).Use(createdById)
                .OnProperty(company => company.UpdatedBy).Use(createdById);

            return filler;
        }
        private static IQueryable<Company> CreateRandomCompanies(DateTimeOffset dates) =>
            CreateCompanyFiller(dates).Create(GetRandomNumber()).AsQueryable();

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();


        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => expectedException.Message ==
                actualException.Message &&
                expectedException.InnerException.Message == actualException.InnerException.Message;
        }
    }
}
