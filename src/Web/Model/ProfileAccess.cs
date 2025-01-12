namespace Web.Model;

public record ProfileAccess(AccessLevel Value, string Text)
{
    public static IReadOnlyList<ProfileAccess> GetProfileAccess { get; } =
    [
        new(AccessLevel.None, ""),
        new(AccessLevel.Admin, "Administrador"),
        new(AccessLevel.Manager, "Gerente"),
        new(AccessLevel.Supervisor, "Supervisore"),
        new(AccessLevel.Leader, "Lider"),
        new(AccessLevel.Consultant, "Consultor")
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