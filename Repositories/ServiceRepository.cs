using DevPulseApi.Data;
using DevPulseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevPulseApi.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
    }

    public async Task  CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}