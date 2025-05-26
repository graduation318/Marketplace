using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketplace.Service;
using Marketplace.Data;
using Marketplace.Service.Interface;
using Marketplace.Service.ModelsRequest;

namespace Marketplace.Api.Controllers;

public class CharacteristicController : WebApiController
{
    private readonly ICharacteristicService _characteristicService;
    private readonly ILogger<CharacteristicController> _logger;

    public CharacteristicController(CharacteristicService characteristicService, ILogger<CharacteristicController> logger)
    {
        _characteristicService = characteristicService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var items = await _characteristicService.GetAllAsync(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _characteristicService.GetByIdAsync(id, cancellationToken);
        return item != null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Characteristic model, CancellationToken cancellationToken = default)
    {
        var created = await _characteristicService.CreateAsync(model, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CharacteristicRequest model, CancellationToken cancellationToken = default)
    {
        var updated = await _characteristicService.UpdateAsync(id, model, cancellationToken);
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _characteristicService.DeleteAsync(id, cancellationToken);
        return result ? NoContent() : NotFound();
    }
}