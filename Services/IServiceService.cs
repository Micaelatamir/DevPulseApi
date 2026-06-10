using DevPulseApi.DTOs;
using DevPulseApi.Models;

namespace DevPulseApi.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(Guid id);
    Task<Service> CreateAsync(CreateServiceDto dto);
}