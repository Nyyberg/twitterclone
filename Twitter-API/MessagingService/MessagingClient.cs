using EasyNetQ;

namespace MessagingService
{
    public class MessagingClient : IMessagingClient
    {
        private readonly IBus _bus;

        public MessagingClient(IBus bus)
        {
            _bus = bus;
        }

        public async Task Send<T>(T message, string topic)
        {
            await Task.Run(() => { _bus.PubSub.PublishAsync(message, topic); });
        }

        public async Task Listen<T>(Action<T> handler, string topic)
        {
            await Task.Run(() => { _bus.PubSub.SubscribeAsync(topic, handler); });
        }

    }
}
