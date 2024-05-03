using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingService
{
    public interface IMessagingClient
    {
        Task Send<T>(T message, string topic);
        Task Listen<T>(Action<T> handler, string topic);
        
    }
}
