using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("Address")]
public class AddressController(AddressService addressService) : ControllerBase
{
    private readonly AddressService _addressService = addressService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> GetAll()
    {
        var addresses = await _addressService.GetAllAsync();
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> GetById(int id)
    {
        var address = await _addressService.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return Ok(address);
    }

    [HttpPost]
    public async Task<ActionResult<Address>> Create(Address address)
    {
        var createdAddress = await _addressService.CreateAsync(address);
        return CreatedAtAction(nameof(GetById), new { id = createdAddress.Id }, createdAddress);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Address>> Update(int id, Address address)
    {
        var updatedAddress = await _addressService.UpdateAsync(id, address);
        if (updatedAddress == null)
        {
            return NotFound();
        }
        return Ok(updatedAddress);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _addressService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent(); // 204 No Content
    }
}
