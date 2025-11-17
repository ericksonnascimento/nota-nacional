using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Abrasf.Core.Helpers
{

    public class ParseHelper
    {
        public static T ParseXml<T>(string value) where T : class
        {
            using var stream = GenerateStreamFromString(value.Trim());
            var reader = XmlReader.Create(stream, new XmlReaderSettings()
            {
                ConformanceLevel = ConformanceLevel.Document
            });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T ?? throw new InvalidOperationException();
        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string GetXml(object? data)
        {
            if (data is null)
            {
                throw new ArgumentException("Invalid data");
            }

            var parsedData = (data as XmlNode[] ?? Array.Empty<XmlNode>());
            if (parsedData.Length == 1)
            {
                return parsedData.First().OuterXml;
            }

            var skip = parsedData[0].Value.Equals("<") ? 0 : 1;

            var builder = new StringBuilder();
            var closingQuotes = new List<string>();

            foreach (var node in parsedData.Skip(skip))
            {
                builder.Append(node.OuterXml);

                if (node.OuterXml.Equals("\""))
                {
                    closingQuotes.Add("");
                }

                if (closingQuotes.Any() && closingQuotes.Count % 2 == 0)
                {
                    builder.Append(" ");
                    closingQuotes.Clear();
                }
            }

            return builder.ToString().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"");
        }
    }
}