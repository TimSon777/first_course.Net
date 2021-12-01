using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using hw9;
using hw9.Services.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Tests9
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer())
                .ConfigureServices(a => a.AddDbContext<ApplicationDbContext>());
    }

    public class IntegrationTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;

        public IntegrationTests(HostBuilder fixture)
        {
            _client = fixture.CreateClient();
        }

        private static readonly Uri Uri = new("https://localhost:5001/Calculator/Calculate");
        
        private const string ErrorNotValidBrackets = "Wrong brackets";
        private const string ErrorNotValidExpression = "Wrong parameters";
        
        [Theory]
        [InlineData("4 Plus 5", "9")]
        [InlineData("4 Minus 5", "-1")]
        [InlineData("4 Multiplication 5", "20")]
        [InlineData("5 Division 5", "1")]
        [InlineData("(5 Division 5) Plus 1", "2")]
        public async Task CalculatorController_ReturnCorrectResult(string expression, string expected)
            => await MakeTestAsync(expression, expected);
        
        [Theory]
        [InlineData("error", ErrorNotValidExpression)]
        [InlineData(")5 Plus 3(", ErrorNotValidBrackets)]
        [InlineData("(2 Plus 23))", ErrorNotValidBrackets)]
        [InlineData("(2 Plus 23) division division", ErrorNotValidExpression)]
        [InlineData("(2 Plus 23)())", ErrorNotValidBrackets)]
        public async Task CalculatorController_ReturnError(string expression, string excepted)
            => await MakeTestAsync(expression, excepted);

        private async Task MakeTestAsync(string expression, string expected)
        {
            var post = new HttpRequestMessage(HttpMethod.Post, "/Calculator/Calculate");
            var formModel = new Dictionary<string, string>
            {
                { "expression", expression }
            };

            post.Content = new FormUrlEncodedContent(formModel);
            var response = await _client.SendAsync(post);
            var result = await response.Content.ReadAsStringAsync();
            Assert.Contains(GenerateExcepted(expected), result);
        }

        private static string GenerateExcepted(string str)
            => @"<span id=""result"" class=""form-control"">" + str;
        
        [Fact]
        private async Task CalculatorController_CashedTest()
        {
            var rnd = new Random();
            var expression = $"{rnd.Next(0, int.MaxValue / 2)} plus {rnd.Next(0, int.MaxValue / 2)}";
            
            var str = $"expression={expression}";
            var stringContent = new StringContent(str, Encoding.UTF8);
            stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            
            var before = await MeasureTime(stringContent);
            var after = await MeasureTime(stringContent);
            Assert.True(before - after > 1000);
        }

        private async Task<long> MeasureTime(HttpContent stringContent)
        {
            var watch = new Stopwatch();
            watch.Start();
            using var response = await _client.PostAsync(Uri, stringContent);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}