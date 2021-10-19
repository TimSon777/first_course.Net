using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests5
{
    public class IntegrationTests
    {
        private const string Localhost = "http://localhost:5000";
        
        [Theory]
        [InlineData("2", "plus", "3", "5.0")]
        [InlineData("5", "minus", "2.5", "2.5")]
        [InlineData("5", "divide", "4", "1.25")]
        [InlineData("4", "multiply", "4.1", "16.4")]
        [InlineData("-4", "multiply", "4.1", "-16.4")]
        public async Task TestCalculate_Correct(string v1, string op, string v2, string expected)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-us");
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{Localhost}/calculate?v1={v1}&operation={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected,  result);
        }
        
        [Theory]
        [InlineData("4", "ерунда", "4.1", "\"Not a valid operation. Expected: plus, minus, multiply, divide\"")]
        [InlineData("ерунда", "plus", "4.1", "\"Could not parse value 'ерунда' to type System.Decimal.\"")]
        public async Task TestCalculate_Wrong(string v1, string op, string v2, string expected)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{Localhost}/calculate?v1={v1}&operation={op}&v2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected,  result);
        }
    }
}