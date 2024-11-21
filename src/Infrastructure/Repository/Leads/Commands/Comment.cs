namespace Infrastructure.Repository.Leads.Commands;

public class Comment
{
    public Comment(string type, string title, string description, DateTime createdAt, int userId)
    {
        Type = type;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        UserId = userId;
    }

    public int Id { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
}