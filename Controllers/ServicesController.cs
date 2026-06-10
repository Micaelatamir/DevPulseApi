using DevPulseApi.DTOs;
using DevPulseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevPulseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _service;

    public ServicesController(IServiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _service.GetAllAsync();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var service = await _service.GetByIdAsync(id);

        if (service is null)
            return NotFound();

        return Ok(service);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceDto dto)
    {
        var service = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }
}