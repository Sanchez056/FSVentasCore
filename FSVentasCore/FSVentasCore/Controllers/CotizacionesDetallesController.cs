using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSVentasCore.DAL;
using FSVentasCore.Models;
using FSVentasCore.BLL;

namespace FSVentasCore.Controllers
{
    public class CotizacionesDetallesController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public CotizacionesDetallesController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: CotizacionesDetalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CotizacionesDetalles.ToListAsync());
        }

        // GET: CotizacionesDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionesDetalles = await _context.CotizacionesDetalles
                .SingleOrDefaultAsync(m => m.CotizacionDetalleId == id);
            if (cotizacionesDetalles == null)
            {
                return NotFound();
            }

            return View(cotizacionesDetalles);
        }
        [HttpPost]
        public JsonResult Save([FromBody]List<CotizacionesDetalles> detalles)
        {
            bool resultado = CotizacionesDetallesBLL.Guardar(detalles);
            return Json(resultado);
        }

        // GET: CotizacionesDetalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CotizacionesDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CotizacionDetalleId,CotizacionId,ArticuloId,Cantidad,PrecXund,SubTotal")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacionesDetalles);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cotizacionesDetalles);
        }

        // GET: CotizacionesDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionesDetalles = await _context.CotizacionesDetalles.SingleOrDefaultAsync(m => m.CotizacionDetalleId == id);
            if (cotizacionesDetalles == null)
            {
                return NotFound();
            }
            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CotizacionDetalleId,CotizacionId,ArticuloId,Cantidad,PrecXund,SubTotal")] CotizacionesDetalles cotizacionesDetalles)
        {
            if (id != cotizacionesDetalles.CotizacionDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacionesDetalles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionesDetallesExists(cotizacionesDetalles.CotizacionDetalleId))
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
            return View(cotizacionesDetalles);
        }
        [HttpPost]
      

        // GET: CotizacionesDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacionesDetalles = await _context.CotizacionesDetalles
                .SingleOrDefaultAsync(m => m.CotizacionDetalleId == id);
            if (cotizacionesDetalles == null)
            {
                return NotFound();
            }

            return View(cotizacionesDetalles);
        }

        // POST: CotizacionesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacionesDetalles = await _context.CotizacionesDetalles.SingleOrDefaultAsync(m => m.CotizacionDetalleId == id);
            _context.CotizacionesDetalles.Remove(cotizacionesDetalles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CotizacionesDetallesExists(int id)
        {
            return _context.CotizacionesDetalles.Any(e => e.CotizacionDetalleId == id);
        }
    }
}
