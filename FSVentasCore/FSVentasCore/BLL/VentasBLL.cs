using FSVentasCore.DAL;
using FSVentasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas v)
        {

            bool resultado = false;
            using (var db = new FSVentasCoreDb())

            {
                db.Ventas.Add(v);
                db.SaveChanges();
                resultado = true;
            }

            return resultado;
        }
        public static Ventas Buscar(int ventaId)
        {
            Ventas venta = null;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    venta = db.Ventas.Find(ventaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return venta;
        }
        public static List<Ventas> GetLista()
        {
            var lista = new List<Ventas>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Ventas.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
    }
}
