namespace DevPulseApi.Models;

public class Metric
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string MetricType { get; set; } = string.Empty;
    public double Value { get; set; }
    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    public Guid ServiceId { get; set; }
    public Service Service { get; set; } = null!;

}