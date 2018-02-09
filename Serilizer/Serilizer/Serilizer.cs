using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ConsoleApp3
{
    public class Serilizer
    {
        public static string WriteFromObject(Object input)
        {
            //Create User object.  
            //Create a stream to serialize the object to.  
            MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(input.GetType());
            ser.WriteObject(ms, input);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);

        }

        // Deserialize a JSON stream to a User object.  
        public static Object ReadToObject(string json, Type type)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(type);
            var result = ser.ReadObject(ms);
            ms.Close();
            return result;
        }
    }
}
