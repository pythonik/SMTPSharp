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
        public void TestGetStatusCodeWithErroneousInput()
        {
            var testResponse = "SomethingWrongNoStatusCode";
            var statusCode = (int)testResponse.GetStatusCode();
            Assert.True(statusCode == 0);
        }

        [Fact]
        public void TestGetResponseMessage()
        {
            var testResponse = "220 someserverisready";
            var message = testResponse.GetResponseMessage();
            Assert.True(message == "someserverisready");
        }

        [Fact]
        public void TestGetResponseWithErroneousInput()
        {
            var invalidShortMessage = "No";
            var message = invalidShortMessage.GetResponseMessage();
            Assert.True(message == string.Empty);
        }
    }
}
