using System.Xml.Serialization;

namespace Infrastructure.HttpClients.Addresses.HttpClients;

[XmlRoot(ElementName = "ENDERECO")]
public class AddressResponse
{
    [XmlElement(ElementName = "CEP")]
    public string Cep { get; set; }

    [XmlElement(ElementName = "TIPOLOGRADOURO")]
    public string TipoLogradouro { get; set; }

    [XmlElement(ElementName = "LOGRADOURO")]
    public string Logradouro { get; set; }

    [XmlElement(ElementName = "BAIRRO")]
    public string Bairro { get; set; }

    [XmlElement(ElementName = "MUNICIPIO")]
    public string Municipio { get; set; }

    [XmlElement(ElementName = "CODMUNICIPIO")]
    public string CodMunicipio { get; set; }

    [XmlElement(ElementName = "UF")]
    public string Uf { get; set; }

    public static AddressResponse CreateResponse(string response)
    {
        XmlSerializer soapSerializer = new(typeof(SoapEnvelope));
        using StringReader reader = new(response);
        SoapEnvelope envelope = (SoapEnvelope)soapSerializer.Deserialize(reader);
        string encodedReturn = envelope.Body.ConsultaCEPResponse.Return;

        string decodedReturn = System.Net.WebUtility.HtmlDecode(encodedReturn);

        XmlSerializer addressSerializer = new(typeof(AddressResponse));

        using StringReader addressReader = new(decodedReturn);
        return (AddressResponse)addressSerializer.Deserialize(addressReader);
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
    [XmlElement(ElementName = "ConsultaCEPResponse", Namespace = "urn:uTeleport-Teleport")]
    public ConsultaCEPResponse ConsultaCEPResponse { get; set; }
}

public class ConsultaCEPResponse
{
    [XmlElement(ElementName = "return", Namespace = "")]
    public string Return { get; set; }
}