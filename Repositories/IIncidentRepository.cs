using DevPulseApi.Models;

namespace DevPulseApi.Repositories;

public interface IIncidentRepository
{
    Task<IEnumerable<Incident>> GetAllByServiceIdAsync(Guid serviceId);
    Task<Incident?> GetByIdAsync(Guid id);
    Task AddAsync(Incident incident);
    Task UpdateAsync(Incident incident);
    Task CommitAsync();
}