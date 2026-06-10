using DevPulseApi.DTOs;
using DevPulseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevPulseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetricsController : ControllerBase
{
    private readonly IMetricService _service;

    public MetricsController(IMetricService service)
    {
        _service = service;
    }

    [HttpGet("service/{serviceId}")]
    public async Task<IActionResult> GetAllByServiceId(Guid serviceId)
    {
        var metrics = await _service.GetAllByServiceIdAsync(serviceId);
        return Ok(metrics);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMetricDto dto)
    {
        var metric = await _service.CreateAsync(dto);
        return Created(string.Empty, metric);
    }
}