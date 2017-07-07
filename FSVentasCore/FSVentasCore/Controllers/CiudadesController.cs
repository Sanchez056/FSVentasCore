using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSVentasCore.DAL;
using FSVentasCore.Models.Dirreciones;

namespace FSVentasCore.Controllers
{
    public class CiudadesController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public CiudadesController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
            var fSVentasCoreDb = _context.Ciudades.Include(c => c.Provincias);
            return View(await fSVentasCoreDb.ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .Include(c => c.Provincias)
                .SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiudadId,Nombre,ProvinciaId")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudades);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades.SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudades == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiudadId,Nombre,ProvinciaId")] Ciudades ciudades)
        {
            if (id != ciudades.CiudadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadesExists(ciudades.CiudadId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", ciudades.ProvinciaId);
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .Include(c => c.Provincias)
                .SingleOrDefaultAsync(m => m.CiudadId == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudades = await _context.Ciudades.SingleOrDefaultAsync(m => m.CiudadId == id);
            _context.Ciudades.Remove(ciudades);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CiudadesExists(int id)
        {
            return _context.Ciudades.Any(e => e.CiudadId == id);
        }
    }
}
