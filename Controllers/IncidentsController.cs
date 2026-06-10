using DevPulseApi.DTOs;
using DevPulseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevPulseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _service;

    public IncidentsController(IIncidentService service)
    {
        _service = service;
    }

    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetAllByServiceId(Guid serviceId)
    {
        var incidents = await _service.GetAllByServiceIdAsync(serviceId);
        return Ok(incidents);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIncidentDto dto)
    {
        var incident = await _service.CreateAsync(dto);
        return Created(string.Empty, incident);
    }

    [HttpPatch("{id}/resolve")]
    public async Task<IActionResult> Resolve(Guid id)
    {
        var incident = await _service.ResolveAsync(id);

        if (incident is null)
            return NotFound();

        return Ok(incident);
    }
}