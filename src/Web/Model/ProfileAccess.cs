namespace Web.Model;

public record ProfileAccess(int Value, string Text)
{
    public static IReadOnlyList<ProfileAccess> GetProfileAccess { get; } =
    [
        new(6, ""),
        new(1, "Administrador"),
        new(2, "Gerente"),
        new(3, "Supervisore"),
        new(4, "Lider"),
        new(5, "Consultor")
    ];

    public static ProfileAccess GetByValue(string value) =>
        GetProfileAccess.FirstOrDefault(option => option.Value.ToString() == value);
}

public enum AccessLevel: int
{
    Admin = 1,
    Manager,
    Supervisor,
    Leader,
    Consultant,
    None
}