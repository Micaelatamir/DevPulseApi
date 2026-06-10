using DevPulseApi.DTOs;
using DevPulseApi.Models;

namespace DevPulseApi.Services;

public interface IIncidentService
{
    Task<IEnumerable<Incident>> GetAllByServiceIdAsync(Guid serviceId);
    Task<Incident> CreateAsync(CreateIncidentDto dto);
    Task<Incident?> ResolveAsync(Guid id);
}