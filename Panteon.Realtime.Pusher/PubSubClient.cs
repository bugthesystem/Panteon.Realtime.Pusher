using Panteon.Sdk;
using Panteon.Sdk.Realtime;
using PusherServer;

namespace Panteon.Realtime.Pusher
{
    public class PubSubClient : IPubSubClient
    {
        private readonly IPusher _pusher;

        public PubSubClient()
            : this(new PusherServer.Pusher(Config.PS_APP_ID, Config.PS_APP_KEY, Config.PS_APP_SECRET))
        {

        }
        public PubSubClient(IPusher pusher)
        {
            _pusher = pusher;
        }

        public IPubSubResult Publish<T>(T message) where T : class, IPubSubMessage
        {
            Requires.NotNull(message, nameof(message));
            Requires.NotNullOrEmpty(message.Channel, nameof(message.Channel));
            Requires.NotNullOrEmpty(message.Event, nameof(message.Event));
            Requires.NotNull(message.Payload, nameof(message.Payload));

            ITriggerResult triggerResult = _pusher.Trigger(message.Channel, message.Event, message.Payload);

            return new PusherResult
            {
                Body = triggerResult.Body,
                StatusCode = triggerResult.StatusCode
            };
        }
    }
}