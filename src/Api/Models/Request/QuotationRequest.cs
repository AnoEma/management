namespace Api.Models.Request;

internal record QuotationRequest
(
Segurado Segurado,
Condutor Condutor,
Veiculo Veiculo,
Endereco Endereco,
int TipoLead
);

internal record Segurado
(
string NomeCompleto,
int TipoPessoa,
string Cpf,
string DataNascimento,
string Genero,
string Email,
string Telefone
);

internal record Condutor
(
string Cpf,
string NomeCompleto,
string Genero,
string DataNascimento
);

internal record Veiculo
(
string Marca,
string AnoModelo,
string ZeroKm,
string Modelo,
string Placa,
string Utilizacao,
string CepPerNoite,
string CepResidencia,
string Chassi
);

internal record Endereco
(
string Rua,
string Numero,
string Bairro,
string Cidade,
string Estado,
string CEP,
string? Complemento
);