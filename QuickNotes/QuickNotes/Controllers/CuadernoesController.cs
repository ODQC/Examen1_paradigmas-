using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuickNotes.Data;
using QuickNotes.Models;

namespace QuickNotes.Controllers
{
    public class CuadernoesController : Controller
    {
        private readonly DataContext _context;

        public CuadernoesController(DataContext context)
        {
            _context = context;
        }

        // GET: Cuadernoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuadernos.ToListAsync());
        }

        // GET: Cuadernoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaderno = await _context.Cuadernos
                .FirstOrDefaultAsync(m => m.IdCuarderno == id);
            if (cuaderno == null)
            {
                return NotFound();
            }

            return View(cuaderno);
        }

        // GET: Cuadernoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuadernoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuarderno,NombreCuaderno,Categoria,Color,Orden")] Cuaderno cuaderno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuaderno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuaderno);
        }

        // GET: Cuadernoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaderno = await _context.Cuadernos.FindAsync(id);
            if (cuaderno == null)
            {
                return NotFound();
            }
            return View(cuaderno);
        }

        // POST: Cuadernoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCuarderno,NombreCuaderno,Categoria,Color,Orden")] Cuaderno cuaderno)
        {
            if (id != cuaderno.IdCuarderno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuaderno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuadernoExists(cuaderno.IdCuarderno))
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
            return View(cuaderno);
        }

        // GET: Cuadernoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuaderno = await _context.Cuadernos
                .FirstOrDefaultAsync(m => m.IdCuarderno == id);
            if (cuaderno == null)
            {
                return NotFound();
            }

            return View(cuaderno);
        }

        // POST: Cuadernoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuaderno = await _context.Cuadernos.FindAsync(id);
            _context.Cuadernos.Remove(cuaderno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuadernoExists(int id)
        {
            return _context.Cuadernos.Any(e => e.IdCuarderno == id);
        }
    }
}
