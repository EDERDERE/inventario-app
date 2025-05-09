﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ProductosController : Controller
{
    private readonly InventarioContext _context;

    public ProductosController(InventarioContext context)
    {
        _context = context;
    }

    // GET: Productos
    public async Task<IActionResult> Index()
    {
        return View();
    }

    // GET: Productos/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Productos/Create
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Precio,Cantidad")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: Productos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    // POST: Productos/Edit/5
    [HttpPost] 
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Precio,Cantidad")] Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    // GET: Productos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: Productos/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductoExists(int id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}
