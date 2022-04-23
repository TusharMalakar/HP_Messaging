
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace HP_Messaging.Services
{
    public class NotificationService : Hub<ITypedHubClient>
    {
    }

    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
