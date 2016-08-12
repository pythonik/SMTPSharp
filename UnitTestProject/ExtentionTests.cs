using Xunit;
using Smtp.Net.Core;
namespace UnitTestProject
{
    public class ExtentionTests
    {
        [Fact]
        public void TestGetStatusCode()
        {
            var testResponse = "220 someserverisready";
            var statusCode = (int)testResponse.GetStatusCode();
            Assert.True(statusCode == 220);
        }

        [Fact]
        public void TestGetResponseMessage()
        {
            var testResponse = "220 someserverisready";
            var message = testResponse.GetResponseMessage();
            Assert.True(message == "someserverisready");
        }
    }
}
