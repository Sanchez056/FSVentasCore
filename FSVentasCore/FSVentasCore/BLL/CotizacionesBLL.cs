using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class CotizacionesBLL
    {
       
        public static bool Guardar(Cotizaciones nueva)
        {
           
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
                
            {
                db.Cotizaciones.Add(nueva);
                db.SaveChanges();
                resultado = true;
            }

            return resultado;
        }
        public static List<Cotizaciones> GetLista()
        {
            var lista = new List<Cotizaciones>();
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    lista = conexion.Cotizaciones.ToList();
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

