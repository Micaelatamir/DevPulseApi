namespace DevPulseApi.DTOs;

public class CreateMetricDto
{
    public string MetricType { get; set; } = string.Empty;
    public double Value { get; set; }
    public Guid ServiceId { get; set; }
}