using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using hw5;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests5
{
    public class HostBuilder : WebApplicationFactory<App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<App.Startup>()
                    .UseTestServer());
    }
    
    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;
        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }
        
        private const string Localhost = "http://localhost:5000";
        
        [Theory]
        [InlineData("2", "plus", "3", "5.0")]
        [InlineData("5", "minus", "2.5", "2.5")]
        [InlineData("5", "divide", "4", "1.25")]
        [InlineData("4", "multiply", "4.1", "16.4")]
        [InlineData("-4", "multiply", "4.1", "-16.4")]
        public async Task TestCalculate_Correct(string v1, string op, string v2, string expected)
        {
            await CommonPartTests(v1, op, v2, expected);
        }
        
        [Theory]
        [InlineData("4", "ерунда", "4.1", "\"Could not parse value 'ерунда' to type hw5.Operation.\"")]
        [InlineData("ерунда", "plus", "4.1", "\"Could not parse value 'ерунда' to type System.Decimal.\"")]
        public async Task TestCalculate_Wrong(string v1, string op, string v2, string expected)
        {
            await CommonPartTests(v1, op, v2, expected);
        }

        private async Task CommonPartTests(string v1, string op, string v2, string expected)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-us");
            var response = await _client.GetAsync($"{Localhost}/calculate?v1={v1}&operation={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected,  result);
        }
    }
}