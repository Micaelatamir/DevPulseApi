namespace DevPulseApi.Models;

public class Incident
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public String Title { get; set; } = String.Empty;
    public String Description { get; set; } = String.Empty;
    public DateTime DetectedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ResolvedAt { get; set; }
    public bool IsResolved { get; set; }
    public Guid ServiceId { get; set; }
    public Service Service { get; set; } = null!; 
    
    
}