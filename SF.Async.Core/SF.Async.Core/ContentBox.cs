using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public class ContentBox : IContentBox
    {
        public string Type { get; set; }

        public string PayLoad { get; set ; }

        public static IContentBox CreateFromObject(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var Serializer = new DataContractJsonSerializer(obj.GetType());
                Serializer.WriteObject(stream, obj);
                stream.Position = 0;
                byte[] json = stream.ToArray();
                return new ContentBox
                {
                    Type = obj.GetType().FullName,
                    PayLoad = Encoding.UTF8.GetString(json, 0, json.Length)
                };
            }

        }
    }
}
