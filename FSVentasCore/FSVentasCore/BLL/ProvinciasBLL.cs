using FSVentasCore.DAL;
using FSVentasCore.Models.Dirreciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class ProvinciasBLL
    {
        public static List<Provincias> GetLista()
        {
            var lista = new List<Provincias>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Provincias.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Provincias> GetListaId(int Id)
        {
            List<Provincias> list = new List<Provincias>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Provincias.Where(p => p.ProvinciaId == Id).ToList();
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
