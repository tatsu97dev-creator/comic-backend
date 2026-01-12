namespace Comic.Api.Domain.Entities;

public sealed class Work
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public long? PublisherId { get; private set; }

    // EF Core用（privateでOK）
    private Work() { }

    public Work(string name, long? publisherId = null)
    {
        SetName(name);
        SetPublisher(publisherId);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name.Trim();
    }

    public void SetPublisher(long? publisherId)
    {
        PublisherId = publisherId;
    }
}
