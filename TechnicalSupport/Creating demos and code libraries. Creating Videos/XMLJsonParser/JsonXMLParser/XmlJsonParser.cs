namespace JsonXmlParser
{
    using System;
    using System.Linq;
    using System.Xml;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides methods for:
    /// 1. Converting Xml to Json.
    /// 2. Converting Json to Xml.
    /// </summary>
    public static class XmlJsonParser
    {
        /// <summary>
        /// Converts Xml document to json string.
        /// </summary>
        /// <param name="xmlDoc">The Xml document, which will be converted.</param>
        /// <returns>Json string</returns>
        public static string XmlToJson(XmlDocument xmlDoc)
        {
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);

            return jsonText;
        }

        /// <summary>
        /// Converts Json string to Xml document.
        /// </summary>
        /// <param name="json">The Json string, which will be converted.</param>
        /// <returns>Xml Document</returns>
        public static XmlDocument JsonToXml(string json)
        {
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);

            return doc;
        }
    }
}
