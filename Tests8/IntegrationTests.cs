using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using hw8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests8
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
        private readonly HttpClient _client;

        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        private static readonly Uri Uri = new("https://localhost:5001/Calculator/Calculate");
        private const string Error = "Wrong parameters";
        
        [Theory]
        [InlineData("4 Plus 5", "9")]
        [InlineData("4 Minus 5", "-1")]
        [InlineData("4 Multiplication 5", "20")]
        [InlineData("5 Division 5", "1")]
        [InlineData("(5 Division 5) Plus 1", "2")]
        public async Task CalculatorController_ReturnCorrectResult(string expression, string expected)
            => await MakeTestAsync(expression, expected);
        
        [Theory]
        [InlineData("error")]
        [InlineData(")5 Plus 3(")]
        [InlineData("(2 Plus 23))")]
        [InlineData("(2 Plus 23) division division")]
        [InlineData("(2 Plus 23)())")]
        public async Task CalculatorController_ReturnError(string expression)
            => await MakeTestAsync(expression, Error);

        private async Task MakeTestAsync(string expression, string expected)
        {
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            using var response = await _client.PostAsync(Uri, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = GerResult(content);
            Assert.Equal(expected, result);
        }

        private static string GerResult(string str) 
            => str.Split(@"<span id=""result"" class=""form-control"">")[1]
                .Split("</span")[0];
        
        [Theory]
        [InlineData("(2 plus 3) division 12 multiplication 7 plus 8 multiplication 9")]
        private async Task CalculatorController_ParallelTest(string expression)
        {
            var watch = new Stopwatch();
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            watch.Start();
            using var response = await _client.PostAsync(Uri, stringContent);
            watch.Stop();
            var result = watch.ElapsedMilliseconds;
            Assert.True(result - 1000 < 500);
        }
    }
}