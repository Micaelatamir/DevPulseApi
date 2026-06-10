using DevPulseApi.Models;

namespace DevPulseApi.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(Guid id);
    Task AddAsync(Service service);
    Task CommitAsync();
}