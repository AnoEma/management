namespace Api.Models.Request;

internal record QuotationRequest
(
int TIPOSEG,
Segurado SEGURADO,
Proprietario PROPRIETARIO,
CondutorP CONDUTORP,
Veiculo VEICULO
);

internal record Segurado
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

internal record Proprietario
(
string NOMEPROP,
string PESSOAPROP,
string CGCPROP,
string SEXOPROP,
string ESTCIVILPROP,
string NASCPROP
);

internal record CondutorP
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

internal record Condutor17A25
(
int EXISTE17A25
);

internal record Veiculo
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
int LOCALPERNOITE,
DadosVeiculo Dadosveiculo
);

internal record PerfilUsoVeic
(
int USO
);

internal record DadosVeiculo
(
string MarcaVeiculo,
string AnoModelo,
string ModeloVeiculo
);