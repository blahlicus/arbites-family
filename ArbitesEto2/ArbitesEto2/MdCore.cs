using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System;

namespace ArbitesEto2
{
    public static class MdCore
    {
        public static string Serialize<T>(T @object)
        {
            return null;
        }

        public static T Deserialize<T>(string data)
            where T : new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var stream = data.ToStream())
                {
                    return (T)serializer.Deserialize(stream);
                }
            }
            catch
            {
                return new T();
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
