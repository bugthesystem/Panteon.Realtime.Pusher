using Panteon.Sdk;
using Panteon.Sdk.Realtime;
using PusherServer;

namespace Panteon.Realtime.Pusher
{
    public class PubSubClient : IPubSubClient
    {
        private readonly IPusher _pusher;

        //TODO: DI & config
        public PubSubClient()
            : this(new PusherServer.Pusher("136366", "629772c3ccd3b206462f", "e8b85c485017aa886979"))
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