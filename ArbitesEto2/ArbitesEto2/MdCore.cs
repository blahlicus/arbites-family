using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System;

namespace ArbitesEto2
{
    public static class MdCore
    {
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

        public static void SerializeToPath<T>(T obj, string path)
        {
            var streamWriter = new StreamWriter(path, false);
            var serializer = new JsonSerializer();
            serializer.Serialize(streamWriter, obj);
            streamWriter.Close();
        }

        public static T DeserializeFromPath<T>(string path)
        {
            var streamReader = new StreamReader(path);
            var jsonReader = new JsonTextReader(streamReader);
            var serializer = new JsonSerializer();
            var output = serializer.Deserialize<T>(jsonReader);

            jsonReader.Close();
            streamReader.Close();

            return output;
        }
    }
}
