using Common.Testing.NUnit;
using FluentAssertions;
using NUnit.Framework;
using Panteon.Sdk.Realtime;

namespace Panteon.Realtime.Pusher.Tests
{
    public class PubSubClientTests : TestBase

    {
        [Test]
        public void Init_Test()
        {
            IPubSubClient client = new PubSubClient();

            client.Should().NotBeNull();
        }
    }
}
