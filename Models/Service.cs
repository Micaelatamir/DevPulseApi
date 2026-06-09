namespace DevPulseApi.Models;

public class Service
{
    public Guid Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public String Url { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
}

