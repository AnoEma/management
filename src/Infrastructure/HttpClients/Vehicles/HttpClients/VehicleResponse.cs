namespace Infrastructure.HttpClients.Vehicles.HttpClients;

public record VehicleResponse(
string ano_fabricacao,
string ano_modelo,
string chassi,
string cidade,
string cilindradas,
string combustivel,
string cor,
int cor_mol,
string especie_veiculo,
string estado,
List<Fipe> Fipe,
string marca,
string modelo,
string placa,
string potencia,
string procedencia,
string quantidade_eixos,
string quantidade_passageiros,
string tipo_carroceria,
string tipo_veiculo
);

public record teleport_data(
int classe,
int cod_car,
string cod_marca,
int fim_fabr,
string fipe,
int ini_fabr,
string marca,
string modelo,
int passageiros
);

public record Fipe(
string codigo,
string descricao,
List<teleport_data> teleport_data
);
