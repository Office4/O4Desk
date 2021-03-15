using System;

namespace O4Desk.Web.Api.Brokers.DateTime
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}
