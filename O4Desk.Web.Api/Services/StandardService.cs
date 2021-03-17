using O4Desk.Web.Api.Brokers.DateTime;
using O4Desk.Web.Api.Brokers.Logging;
using O4Desk.Web.Api.Brokers.Storage;

namespace O4Desk.Web.Api.Services
{
    public class StandardService
    {
        public readonly IStorageBroker storageBroker;
        public readonly ILoggingBroker loggingBroker;
        public readonly IDateTimeBroker dateTimeBroker;

        public StandardService(IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

    }
}
