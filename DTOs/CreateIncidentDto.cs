namespace DevPulseApi.DTOs;

public class CreateIncidentDto
{
    public string Title { get; set; } =string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid  ServiceId{ get; set; } 
    
}