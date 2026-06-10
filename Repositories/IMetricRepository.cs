using DevPulseApi.Models;

namespace DevPulseApi.Repositories;

public interface IMetricRepository
{
    Task<IEnumerable<Metric>> GetAllByServiceIdAsync(Guid serviceId);
    Task AddAsync(Metric metric);
    Task CommitAsync();
}