using Xunit;

namespace O4Desk.Web.Api.Tests.Acceptance.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]

    public class ApiTestCollection : ICollectionFixture<O4DeskApiBroker>
    {
    }
}
