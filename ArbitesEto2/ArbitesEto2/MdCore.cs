using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System;

namespace ArbitesEto2
{
    public static class MdCore
    {
        public static void SerializeToPath<T>(T obj, string path)
        {
            using (var streamWriter = new StreamWriter(path, false))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(streamWriter, obj);
            }
        }

        public static T DeserializeFromPath<T>(string path)
            where T : class, new()
        {
            using (var stream = new StreamReader(path))
            {
                return Deserialize<T>(stream.ReadToEnd());
            }
        }

        public static T Deserialize<T>(string data)
            where T : class, new()
        {
            return DeserializeXml<T>(data)
                ?? DeserializeJson<T>(data)
                ?? new T();
        }

        static T DeserializeXml<T>(string data)
            where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(data.ToStream());
            }
            catch
            {
                return null;
            }
        }

        static T DeserializeJson<T>(string data)
            where T : class
        {
            try
            {
                var jsonReader = new JsonTextReader(data.ToStream());
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
            catch
            {
                return null;
            }
        }
    }
}
