using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace ToDoList.WebApp.AppHub
{
    public class LogHub : Hub
    {
        public static bool NotStarted = true;
        public static readonly Timer timer = new Timer();

        public LogHub()
        {
            
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Message", user, message);
        }
    }
}
