namespace Comic.Api.Domain.Entities;

public sealed class Author
{
    public long Id { get; set; }
    public string Name { get; set; } = "";

    // EF Core用（privateでOK）
    private Author() { }

    public Author(string name)
    {
        SetName(name);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name.Trim();
    }
}
