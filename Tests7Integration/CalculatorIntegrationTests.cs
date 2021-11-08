using System.Net.Http;
using System.Threading.Tasks;
using hw7;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests7Integration
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private const string Path = "https://localhost:5001/Calculator/Calculate";
        private readonly HttpClient _client;
        
        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("5", "plus", "5", "10")]
        [InlineData("5", "minus", "5", "0")]
        [InlineData("5", "division", "5", "1")]
        [InlineData("5", "multiplication", "5", "25")]
        public async Task Calculate_ValidArguments_Correct(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }
        
        [Theory]
        [InlineData("error", "plus", "5", "Ожидалось число")]
        [InlineData("5", "minus", "error", "Ожидалось число")]
        [InlineData("5", "error", "5", "Ожидалось: plus, minus, multiplication или division")]
        [InlineData("5", "division", "0", "Infinity")]
        [InlineData("0", "division", "0", "Результат не определен")]
        public async Task Calculate_InvalidArguments_Wrong(string v1, string op, string v2, string excepted)
        {
            await MakeGeneralPartTests(v1, op, v2, excepted);
        }

        private async Task MakeGeneralPartTests(string v1, string op, string v2, string excepted)
        {
            var response = await _client.GetAsync($"{Path}?firstValue={v1}&operation={op}&secondValue={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(excepted, result);
        }
    }
}