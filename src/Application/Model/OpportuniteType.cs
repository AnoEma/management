using System.ComponentModel;

namespace Application.Model;

public enum OpportuniteType: byte
{
    [Description("Seguro Novo")]
    NewInsurance = 1,
    [Description("Renovação")]
    Renewal = 2,
    [Description("Endosso")]
    Endorsement = 3
}
