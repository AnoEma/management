using Newtonsoft.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.Extensions;

public static class JsonHttpContentSerializationExtension
{
    public static StringContent SerializeRequest(this object request, string application)
    {
        var json = request.Serialize();
        return new StringContent(json, Encoding.UTF8, application);
    }

    public static string Serialize(this object request)
    {
        return JsonConvert.SerializeObject(request);
    }

    #region Serialize Request XML
    public static string SerializeRequestToXml(this object request)
    {
        XmlDocument xmlDocument = JsonConvert.DeserializeXmlNode(Serialize(request));

        string xmlString = BeautifyXml(xmlDocument);
        return xmlString;
    }

    private static string BeautifyXml(XmlDocument doc)
    {
        using var stringWriter = new System.IO.StringWriter();
        using var xmlTextWriter = new XmlTextWriter(stringWriter);

        xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
        doc.WriteTo(xmlTextWriter);
        return stringWriter.ToString();
    }
    #endregion

    #region Deserialize Response XML
    public static T DeserializeFromXml<T>(this string xml)
    {
        XmlSerializer serializer = new(typeof(T));
        using StringReader reader = new(xml);
        return (T)serializer.Deserialize(reader);
    }

    public static string DecodeHtml(this string encodedString)
    {
        return System.Net.WebUtility.HtmlDecode(encodedString);
    }

    #endregion
}
