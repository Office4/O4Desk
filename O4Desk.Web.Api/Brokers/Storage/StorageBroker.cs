using Microsoft.Extensions.Configuration;

namespace O4Desk.Web.Api.Brokers.Storage
{
    public class StorageBroker : IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker()
        {

        }
    }
}
