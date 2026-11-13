using CafeteriaBackend.Data;
using CafeteriaBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly CafeteriaDbContext _context;

    public ProveedoresController(CafeteriaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Proveedor>> Crear([FromBody] Proveedor proveedor)
    {
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Crear), new { id = proveedor.Id }, proveedor);
    }
}