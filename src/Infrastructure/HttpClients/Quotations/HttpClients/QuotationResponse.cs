using Infrastructure.Extensions;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

[XmlRoot(ElementName = "XML")]
public class QuotationResponse
{
    [XmlElement(ElementName = "CALCN")]
    public string QuotationId { get; set; }

    [XmlElement(ElementName = "NOVOTOKEN")]
    public string QuotationToken { get; set; }

    public static QuotationResponse CreateResponse(string value)
    {
        string encodedReturn = value.DeserializeFromXml<SoapEnvelope>().Body.GravarCalculoResponse.Return;
        string decodedReturn = encodedReturn.DecodeHtml();

        return decodedReturn.DeserializeFromXml<QuotationResponse>();
    }
}

[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class SoapEnvelope
{
    [XmlElement(ElementName = "Body")]
    public SoapBody Body { get; set; }
}

public class SoapBody
{
    [XmlElement(ElementName = "GravarCalculoResponse", Namespace = "urn:uTeleport-Teleport")]
    public GravarCalculoResponse GravarCalculoResponse { get; set; }
}

public class GravarCalculoResponse
{
    [XmlElement(ElementName = "return", Namespace = "")]
    public string Return { get; set; }
}
