using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WebSocketConsole.Extensions
{
    public static class BytesExtension
    {
        public static ContentBox AsContentBox(this byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ContentBox));
                var result = ser.ReadObject(ms);
                return (ContentBox)result;
            }
        }

        public static ContentBox AsContentBox(this byte[] bytes, int count)
        {
            using (var ms = new MemoryStream(bytes, 0, count))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ContentBox));
                var result = ser.ReadObject(ms);
                return (ContentBox)result;
            }
        }
    }
}
