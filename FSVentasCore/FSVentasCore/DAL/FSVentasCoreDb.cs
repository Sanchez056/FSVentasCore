using FSVentasCore.Models;
using FSVentasCore.Models.Dirreciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.DAL
{
    public class FSVentasCoreDb: DbContext
    {
        public FSVentasCoreDb(DbContextOptions<FSVentasCoreDb> options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<CategoriasArticulos> CategoriasArticulos { get; set; }
        public DbSet<MarcasArticulos> MarcasArticulos { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Municipios> Municipios { get; set; }
        public DbSet<Cotizaciones> Cotizaciones { get; set; }
        public DbSet<CotizacionesDetalles> CotizacionesDetalles { get; set; }
    }
}
