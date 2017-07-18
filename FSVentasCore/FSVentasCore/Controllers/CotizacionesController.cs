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
    public class CotizacionesController : Controller
    {
        private readonly FSVentasCoreDb _context;

        public CotizacionesController(FSVentasCoreDb context)
        {
            _context = context;    
        }
        [HttpGet]
        public JsonResult Buscar(int id)
        {
            Cotizaciones cotizacion = CotizacionesBLL.Buscar(id);
            if (cotizacion != null)
            {
                return Json(cotizacion);
            }
            else
                return Json(0);
        }
        [HttpPost]
        public JsonResult Guardar(Cotizaciones nueva)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                if (CotizacionesBLL.Guardar(nueva))
                {
                    id = nueva.CotizacionId;
                }
            }
            else
            {
               id = +1;
            }
            return Json(id);
        }

       


        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cotizaciones.ToListAsync());
        }

        // GET: Cotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones
                .SingleOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CotizacionId,ClienteId,Articulo,Fecha,Cantidad,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones.SingleOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizaciones == null)
            {
                return NotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CotizacionId,ClienteId,Articulo,Fecha,Cantidad,Monto")] Cotizaciones cotizaciones)
        {
            if (id != cotizaciones.CotizacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionesExists(cotizaciones.CotizacionId))
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
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones
                .SingleOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizaciones = await _context.Cotizaciones.SingleOrDefaultAsync(m => m.CotizacionId == id);
            _context.Cotizaciones.Remove(cotizaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CotizacionesExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.CotizacionId == id);
        }
    }
}
