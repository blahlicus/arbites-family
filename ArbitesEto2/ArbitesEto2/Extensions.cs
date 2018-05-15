using System.IO;

namespace ArbitesEto2
{
    public static class Extensions
    {
        public static Stream ToStream(this string data)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(data);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
