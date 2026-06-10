using DevPulseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DevPulseApi.Data;

public class AppDbContext : DbContext 
{  
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
   public DbSet<Service> Services { get; set; }
   public DbSet<Metric> Metrics { get; set; }
   public DbSet<Incident> Incidents { get; set; }
   
}