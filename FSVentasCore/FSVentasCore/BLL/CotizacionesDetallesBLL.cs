using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class CotizacionesDetallesBLL
    {
        public static bool Guardar(List<CotizacionesDetalles> detalles)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    foreach (CotizacionesDetalles detail in detalles)
                    {
                        db.CotizacionesDetalles.Add(detail);
                        db.SaveChanges();
                        resultado = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static bool Eliminar(CotizacionesDetalles nuevo)
        {
            bool resultado = false;
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    Conn.Entry(nuevo).State = EntityState.Deleted;
                    Conn.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static CotizacionesDetalles Buscar(int Id)
        {
            var c = new CotizacionesDetalles();
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    c = Conn.CotizacionesDetalles.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return c;
        }
        public static List<CotizacionesDetalles> GetLista()
        {
            var lista = new List<CotizacionesDetalles>();
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    lista = conexion.CotizacionesDetalles.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }

        public static List<CotizacionesDetalles> Listar()
        {
            List<CotizacionesDetalles> listado = null;
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    listado = conexion.CotizacionesDetalles.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static List<CotizacionesDetalles> Listar(int? cotizacionId)
        {
            List<CotizacionesDetalles> listado = null;
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    listado = conexion.CotizacionesDetalles.Where(d => d.CotizacionId == cotizacionId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static List<CotizacionesDetalles> GetListaId(int Id)
        {
            List<CotizacionesDetalles> list = new List<CotizacionesDetalles>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.CotizacionesDetalles.Where(p => p.CotizacionDetalleId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
    }
}

