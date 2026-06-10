using DevPulseApi.Data;
using DevPulseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevPulseApi.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _context;

    public IncidentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Incident>> GetAllByServiceIdAsync(Guid serviceId)
    {
        return await _context.Incidents
            .Where(i => i.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task<Incident?> GetByIdAsync(Guid id)
    {
        return await _context.Incidents.FindAsync(id);
    }

    public async Task AddAsync(Incident incident)
    {
        await _context.Incidents.AddAsync(incident);
    }

    public async Task UpdateAsync(Incident incident)
    {
        _context.Incidents.Update(incident);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}