using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartInventoryAPI.Models.Product_Management;
using SmartInventoryAPI.Services.Interface;

namespace SmartInventoryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliers()
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierById(int id)
    {
        var supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return Ok(supplier);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddSupplier([FromBody] Supplier? supplier)
    {
        await _supplierService.AddSupplierAsync(supplier);
        return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.SupplierId }, supplier);
    }

    
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(int id, [FromBody] Supplier? supplier)
    {
        if (id != supplier.SupplierId)
        {
            return BadRequest();
        }

        await _supplierService.UpdateSupplierAsync(supplier);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        await _supplierService.DeleteSupplierAsync(id);
        return NoContent();
    }
}
