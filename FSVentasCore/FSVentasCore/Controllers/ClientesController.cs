using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSVentasCore.DAL;
using FSVentasCore.Models;
using FSVentasCore.Models.Dirreciones;

namespace FSVentasCore.Controllers
{
    public class ClientesController : Controller
    {
        private readonly FSVentasCoreDb _context;
        private FSVentasCoreDb db = new FSVentasCoreDb();
        public ClientesController(FSVentasCoreDb context)
        {
            _context = context;    
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var fSVentasCoreDb = _context.Clientes.Include(c => c.Ciudades).Include(c => c.Municipios).Include(c => c.Provincias).Include(c => c.Sector);
            return View(await fSVentasCoreDb.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.Ciudades)
                .Include(c => c.Municipios)
                .Include(c => c.Provincias)
                .Include(c => c.Sector)
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            List<Provincias> lstProvincia = db.Provincias.ToList();
            lstProvincia.Insert(0, new Provincias { ProvinciaId = 0, Nombre = "--Select Provincia--" });
            List<Ciudades> lstCiudades = db.Ciudades.ToList();
            ViewBag.ProvinciaId = new SelectList(lstProvincia, "ProvinciaId", "Nombre");
            ViewBag.CiudadId = new SelectList(lstCiudades, "CiudadId", "Nombre");
            List<Municipios> lstMunicipios = db.Municipios.ToList();
            ViewBag.MunicipioId = new SelectList(lstMunicipios, "MunicipioId", "Nombre");
            List<Sector> lstSector = db.Sector.ToList();
            ViewBag.SectorId = new SelectList(lstSector, "SectorId", "Nombre");

            return View();
        }
        [HttpGet]
        public JsonResult Lista(int? id)
        {
            var listado = BLL.ClientesBLL.ListarClientes();

            return Json(listado);
        }
        public JsonResult GetCiudadByProvinciaId(int id)
        {
            List<Ciudades> ciudades = new List<Ciudades>();
            if (id > 0)
            {
                ciudades = db.Ciudades.Where(p => p.ProvinciaId == id).ToList();

            }
            else
            {
                ciudades.Insert(0, new Ciudades { CiudadId = 0, Nombre = "--Select a Ciudadfirst--" });
            }
            var result = (from r in ciudades
                          select new
                          {
                              CiudadId = r.CiudadId,
                              CiudadNombre = r.Nombre
                          }).ToList();

            return Json(result);
            // return Json(result);

        }
        public JsonResult GetMunicipioIdByCiudadId(int id)
        {
            List<Municipios> municipios = new List<Municipios>();
            if (id > 0)
            {
                municipios = db.Municipios.Where(p => p.CiudadId == id).ToList();

            }
            else
            {
                municipios.Insert(0, new Municipios { MunicipioId = 0, Nombre = "--Select a Ciudadfirst--" });
            }
            var result = (from r in municipios
                          select new
                          {
                              MunicipioId = r.MunicipioId,
                              Nombre = r.Nombre
                          }).ToList();

            return Json(result);
            // return Json(result);

        }
        public JsonResult GetSectorIdByMunicipioId(int id)
        {
            List<Sector> sector = new List<Sector>();
            if (id > 0)
            {
                sector = db.Sector.Where(p => p.MunicipioId == id).ToList();

            }
            else
            {
                sector.Insert(0, new Sector { SectorId = 0, Nombre = "--Select a Ciudad first--" });
            }
            var result = (from r in sector
                          select new
                          {
                              SectorId = r.SectorId,
                              Nombre = r.Nombre
                          }).ToList();

            return Json(result);
            // return Json(result);

        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,Sexo,Cedula,ProvinciaId,CiudadId,MunicipioId,SectorId,Direccion,Telefono,Celular,Fecha")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre", clientes.CiudadId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nombre", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "Nombre", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Sector, "SectorId", "Nombre", clientes.SectorId);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "Nombre", clientes.CiudadId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nombre", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "Nombre", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Sector, "SectorId", "Nombre", clientes.SectorId);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,Sexo,Cedula,ProvinciaId,CiudadId,MunicipioId,SectorId,Direccion,Telefono,Celular,Fecha")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClienteId))
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
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "CiudadId", clientes.CiudadId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "MunicipioId", clientes.MunicipioId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "ProvinciaId", "ProvinciaId", clientes.ProvinciaId);
            ViewData["SectorId"] = new SelectList(_context.Sector, "SectorId", "SectorId", clientes.SectorId);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.Ciudades)
                .Include(c => c.Municipios)
                .Include(c => c.Provincias)
                .Include(c => c.Sector)
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteId == id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
