using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BuckleUp.signalR
{
    public class QuizHub : Hub
    {
        // public async Task SendMessage(string user, string message)
        // {
        //     Console.WriteLine("Sending");
        //     await Clients.All.SendAsync("ReceiveMessage",user, $"the message is {message}");
        // }
    }
}