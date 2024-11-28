using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public record QuotationResponse
(
string QuotationId,
string QuotationToken
)
{
    public static QuotationResponse CreateResponse(string value)
    {
        XmlSerializer serializer = new(typeof(Envelope));
        using StringReader reader = new(value);

        var envelope = (Envelope)serializer.Deserialize(reader);
        string returnValue = envelope.Body.GravarCalculoResponse.Return;

        string decodedXml = System.Net.WebUtility.HtmlDecode(returnValue);

        var doc = new XmlDocument();
        doc.LoadXml(decodedXml);

        string novoToken = doc.SelectSingleNode("//NOVOTOKEN")?.InnerText;
        string calcn = doc.SelectSingleNode("//CALCN")?.InnerText;

        return new
        (
            QuotationId: calcn,
            QuotationToken: novoToken
        );
    }
}

[XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope
{
    [XmlElement("Body")]
    public Body Body { get; set; }
}

public class Body
{
    [XmlElement("GravarCalculoResponse", Namespace = "urn:uTeleport-Teleport")]
    public GravarCalculoResponse GravarCalculoResponse { get; set; }
}

public class GravarCalculoResponse
{
    [XmlElement("return")]
    public string Return { get; set; }
}
