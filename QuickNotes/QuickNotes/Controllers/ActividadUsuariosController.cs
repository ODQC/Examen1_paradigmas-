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
    public class ActividadUsuariosController : Controller
    {
        private readonly DataContext _context;

        public ActividadUsuariosController(DataContext context)
        {
            _context = context;
        }

        // GET: ActividadUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActiviadadUsuarios.ToListAsync());
        }

        // GET: ActividadUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadUsuario = await _context.ActiviadadUsuarios
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividadUsuario == null)
            {
                return NotFound();
            }

            return View(actividadUsuario);
        }

        // GET: ActividadUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActividadUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActividad,IdUsuario,Descripcion,FechaIncidencia")] ActividadUsuario actividadUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividadUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividadUsuario);
        }

        // GET: ActividadUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadUsuario = await _context.ActiviadadUsuarios.FindAsync(id);
            if (actividadUsuario == null)
            {
                return NotFound();
            }
            return View(actividadUsuario);
        }

        // POST: ActividadUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActividad,IdUsuario,Descripcion,FechaIncidencia")] ActividadUsuario actividadUsuario)
        {
            if (id != actividadUsuario.IdActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividadUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadUsuarioExists(actividadUsuario.IdActividad))
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
            return View(actividadUsuario);
        }

        // GET: ActividadUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadUsuario = await _context.ActiviadadUsuarios
                .FirstOrDefaultAsync(m => m.IdActividad == id);
            if (actividadUsuario == null)
            {
                return NotFound();
            }

            return View(actividadUsuario);
        }

        // POST: ActividadUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividadUsuario = await _context.ActiviadadUsuarios.FindAsync(id);
            _context.ActiviadadUsuarios.Remove(actividadUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadUsuarioExists(int id)
        {
            return _context.ActiviadadUsuarios.Any(e => e.IdActividad == id);
        }
    }
}
