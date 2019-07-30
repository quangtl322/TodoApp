using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Common.Helpers;

namespace TodoApp.Common
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {

        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",  message);
        }
    }
}
