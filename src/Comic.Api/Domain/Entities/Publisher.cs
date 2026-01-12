namespace Comic.Api.Domain.Entities;

public sealed class Publisher
{
    public long Id { get; set; }
    public string Name { get; set; } = "";

    // EF Core用（privateでOK）
    private Publisher() { }

    public Publisher(string name)
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
