using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Net.Http;

namespace O4Desk.Web.Api.Tests.Acceptance.Brokers
{
    public class O4DeskApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient httpClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public O4DeskApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.httpClient = webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}
