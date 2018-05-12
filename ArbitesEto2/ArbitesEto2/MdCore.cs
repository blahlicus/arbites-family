using System.IO;
using Newtonsoft.Json;

namespace ArbitesEto2
{
    internal class MdCore
    {
        public static void Serialize<T>(T obj, string path)
        {
            var streamWriter = new StreamWriter(path, false);
            var serializer = new JsonSerializer();
            serializer.Serialize(streamWriter, obj);
            streamWriter.Close();
        }

        public static T Deserialize<T>(string path)
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
