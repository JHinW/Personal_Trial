using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketConsole.Extensions;

namespace WebSocketConsole
{
    public class NetWebsocketClient
    {
        public static async Task Initial()
        {
            var webSocket = new System.Net.WebSockets.ClientWebSocket();
            await webSocket.ConnectAsync(new Uri("ws://localhost:6297/ws"), CancellationToken.None);
            var content = ContentBox.CreateFromObject("wangjinisgood").AsBytes();

            var buffer = new byte[1024 * 4];

            await webSocket.SendAsync(
                new ArraySegment<byte>(content),
                WebSocketMessageType.Binary,
                true, CancellationToken.None);


            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {


                // await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                var ret = (string)buffer.AsContentBox(result.Count).AsSpecific();

                Console.WriteLine($"hellow world:   {ret}");

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            }

            //return Task.CompletedTask;
        }
    }
}
