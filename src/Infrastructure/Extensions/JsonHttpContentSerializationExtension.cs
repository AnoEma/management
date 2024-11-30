using Newtonsoft.Json;
using System.Text;
using System.Xml;

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
}
