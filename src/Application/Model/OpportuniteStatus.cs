using System.ComponentModel;

namespace Application.Model;

public enum OpportuniteStatus: byte
{
    [Description("Não iniciado")]
    NotStarted = 1,
    [Description("Pendente")]
    Pending = 2,
    [Description("Vendido")]
    Sold = 3,
    [Description("Emitido")]
    Issued = 4,
    [Description("Cancelado")]
    Canceled = 5,
    [Description("Não vendido")]
    NotSold = 6
}