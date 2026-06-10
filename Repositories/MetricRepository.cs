using DevPulseApi.Data;
using DevPulseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevPulseApi.Repositories;

public class MetricRepository : IMetricRepository
{
    private readonly AppDbContext _context;

    public MetricRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Metric>> GetAllByServiceIdAsync(Guid serviceId)
    {
        return await _context.Metrics
            .Where(m => m.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task AddAsync(Metric metric)
    {
        await _context.Metrics.AddAsync(metric);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}