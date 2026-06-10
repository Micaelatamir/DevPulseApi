using DevPulseApi.DTOs;
using DevPulseApi.Models;

namespace DevPulseApi.Services;

public interface IMetricService
{
    Task<IEnumerable<Metric>> GetAllByServiceIdAsync(Guid serviceId);
    Task<Metric> CreateAsync(CreateMetricDto dto);
}