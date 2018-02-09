using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core.Extensions
{
    public static class ContentBoxExtension
    {
        public static Object AsSpecific(this IContentBox content)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content.PayLoad)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(Type.GetType(content.Type));
                var result = ser.ReadObject(ms);
                return result;
            }       
        }
    }
}
