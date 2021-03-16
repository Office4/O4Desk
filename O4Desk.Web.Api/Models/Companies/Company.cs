using System;

namespace O4Desk.Web.Api.Models.Companies
{
    public class Company : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
