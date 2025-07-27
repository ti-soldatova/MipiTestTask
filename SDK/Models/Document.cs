using System.Text.Json.Serialization;

namespace SDK.Models;

public record Document
{
    public Guid Id { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DocumentType Type { get; }

    public string Title { get; }

    public User User { get; }

    public string Description { get; }

    public bool IsHighPriority { get; }

    public Document(Guid id, DocumentType type, string title, User user, string description, bool isHighPriority)
    {
        Id = id;
        Type = type;
        Title = title;
        
        if (user is null)
            throw new ArgumentNullException(nameof(user));

        User = user;
        Description = description;
        IsHighPriority = isHighPriority;
    }
}
