namespace Frontpoint.Core.Common;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
}
