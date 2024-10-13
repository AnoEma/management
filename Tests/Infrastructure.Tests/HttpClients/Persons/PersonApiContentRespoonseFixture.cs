using Infrastructure.HttpClients.Persons.HttpClients;
using System.Text.Json;

namespace Infrastructure.Tests.HttpClients.Persons;

public class PersonApiContentRespoonseFixture
{
    public PersonResponse? PersonResponse { get; private set; }

    public PersonApiContentRespoonseFixture()
    {
        CreatePerson();
    }

    private void CreatePerson()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var jsonFilePath = Path.Combine(currentDirectory, "Resources", "get_person.json");
        var jsonContent = File.ReadAllText(jsonFilePath);

        PersonResponse = JsonSerializer.Deserialize<PersonResponse?>(jsonContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }
}
