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
    public class SectorsController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public SectorsController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: Sectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sector.ToListAsync());
        }

        // GET: Sectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .SingleOrDefaultAsync(m => m.SectorId == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Sectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectorId,Nombre")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sector);
        }

        // GET: Sectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector.SingleOrDefaultAsync(m => m.SectorId == id);
            if (sector == null)
            {
                return NotFound();
            }
            return View(sector);
        }

        // POST: Sectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectorId,Nombre")] Sector sector)
        {
            if (id != sector.SectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.SectorId))
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
            return View(sector);
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .SingleOrDefaultAsync(m => m.SectorId == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sector = await _context.Sector.SingleOrDefaultAsync(m => m.SectorId == id);
            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SectorExists(int id)
        {
            return _context.Sector.Any(e => e.SectorId == id);
        }
    }
}
