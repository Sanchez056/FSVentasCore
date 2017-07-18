using FSVentasCore.DAL;
using FSVentasCore.Models.Dirreciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class SectoresBLL
    {
        public static List<Sector> GetLista()
        {
            var lista = new List<Sector>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Sector.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Sector> GetListaId(int Id)
        {
            List<Sector> list = new List<Sector>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Sector.Where(p => p.SectorId == Id).ToList();
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
