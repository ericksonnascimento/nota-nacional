using System.Xml;
using System.Xml.Serialization;

namespace Abrasf.Core.Helpers
{

    public class Serializer<T> where T : class
    {
        public static string Serialize(T obj)
        {
            var xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (var writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }
    }
}