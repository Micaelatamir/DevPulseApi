using DevPulseApi.DTOs;
using DevPulseApi.Models;
using DevPulseApi.Repositories;

namespace DevPulseApi.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;

    public ServiceService(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Service> CreateAsync(CreateServiceDto dto)
    {
        var service = new Service
        {
            Name = dto.Name,
            Url = dto.Url
        };

        await _repository.AddAsync(service);
        await _repository.CommitAsync();

        return service;
    }
}