
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace HP_Messaging.Services
{
    public class BroadcastHub : Hub<IHubClient>
    {
    }

    public interface IHubClient
    {
        Task BroadcastMessage(string type, object payload);
    }

    /*********TO DO*******
     * 1. Create Service to notify a specific Group
     * 2. Create Service to notify a specific chat-user
     * 
     *************** ****/
}
