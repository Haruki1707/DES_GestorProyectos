﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorProyectos.Models;

namespace GestorProyectos.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly GestorProyectosDBContext _context;

        public ProyectosController(GestorProyectosDBContext context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index(string searchString)
        {
            var proyectosDBContext = _context.Proyectos.Include(p => p.Asignaciones).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                proyectosDBContext = proyectosDBContext.Where(s => s.Nombre.Contains(searchString) || s.Descripcion.Contains(searchString));
            }
            return View(await proyectosDBContext.ToListAsync());
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descripcion,FechaInicio")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descripcion,FechaInicio")] Proyecto proyecto)
        {
            if (id != proyecto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.ID))
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
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.ID == id);
        }
    }
}
