using System.Net.Http;
using System.Text;
using MessageBoard.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace MessageBoard.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly HttpClient Client;
        protected readonly TestServer Server;

        protected ControllerTestsBase()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}