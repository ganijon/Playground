using NUnit.Framework;

namespace Playground.Api.Rest.Test
{
    public class ControllerTestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}