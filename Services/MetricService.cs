using DevPulseApi.DTOs;
using DevPulseApi.Models;
using DevPulseApi.Repositories;

namespace DevPulseApi.Services;

public class MetricService : IMetricService
{
    private readonly IMetricRepository _repository;

    public MetricService(IMetricRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Metric>> GetAllByServiceIdAsync(Guid serviceId)
    {
        return await _repository.GetAllByServiceIdAsync(serviceId);
    }

    public async Task<Metric> CreateAsync(CreateMetricDto dto)
    {
        var metric = new Metric
        {
            MetricType = dto.MetricType,
            Value = dto.Value,
            ServiceId = dto.ServiceId
        };

        await _repository.AddAsync(metric);
        await _repository.CommitAsync();

        return metric;
    }
}