namespace Infrastructure.HttpClients.Quotations.HttpClients;

public record QuotationRequest
(
Cotacao COTACAO
);


public record Cotacao
(
int TIPOSEG,
Segurado SEGURADO,
Proprietario PROPRIETARIO,
CondutorP CONDUTORP,
Veiculo VEICULO
);

public record Segurado
(
string NOMESEG,
string PESSOASEG,
string CGCSEG,
string NASCSEG,
string SEXOSEG,
string ESTCIVILSEG,
string EMAILPES,
string DDDCEL,
string CEL,
string RELAPROPR,
string CONTATO
);

public record Proprietario
(
string NOMEPROP,
string PESSOAPROP,
string CGCPROP,
string SEXOPROP,
string ESTCIVILPROP,
string NASCPROP
);

public record CondutorP
(
string CPFCOND,
string NOMECOND,
string SEXOCOND,
string NASCCOND,
string ESTCIVILCOND,
string RESIDEEM,
string RELASEG,
Condutor17A25 CONDS17A25
);

public record Condutor17A25
(
int EXISTE17A25
);

public record Veiculo
(
int CODCAR,
string MARCA,
string ANOFABR,
string ANOMODELO,
string COMBUSTIVEL,
string ZEROKM,
string UTILIZACAO,
PerfilUsoVeic PERFILUSOVEIC,
string CEPPERNOITE,
string CEPCIRC,
string CEPRESID,
string GARAGRESID,
string GARAGTRAB,
int LOCALPERNOITE
);

public record PerfilUsoVeic
(
int USO
);

public record DadosVeiculo
(
string marcaVeiculo,
string anoModelo,
string modeloVeiculo
);
