using DevPulseApi.DTOs;
using DevPulseApi.Models;
using DevPulseApi.Repositories;

namespace DevPulseApi.Services;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _repository;

    public IncidentService(IIncidentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Incident>> GetAllByServiceIdAsync(Guid serviceId)
    {
        return await _repository.GetAllByServiceIdAsync(serviceId);
    }

    public async Task<Incident> CreateAsync(CreateIncidentDto dto)
    {
        var incident = new Incident
        {
            Title = dto.Title,
            Description = dto.Description,
            ServiceId = dto.ServiceId
        };

        await _repository.AddAsync(incident);
        await _repository.CommitAsync();

        return incident;
    }

    public async Task<Incident?> ResolveAsync(Guid id)
    {
        var incident = await _repository.GetByIdAsync(id);

        if (incident is null)
            return null;

        incident.IsResolved = true;
        incident.ResolvedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(incident);
        await _repository.CommitAsync();

        return incident;
    }
}