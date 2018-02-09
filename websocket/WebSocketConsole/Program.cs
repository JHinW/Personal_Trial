using System;
using WebSocketConsole;
using WebSocketSharp;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NetWebsocketClient.Initial().Wait();

            
        }


        public static void bak()
        {
            using (var ws = new WebSocket("ws://localhost:6297/ws"))
            {
                ws.OnMessage += (sender, e) =>
                  Console.WriteLine("Laputa says: " + e.Data);

                ws.Connect();
                ws.Send("BALUSwwwww");
                Console.ReadKey(true);
            }
        }
    }
}