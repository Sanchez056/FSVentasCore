using FSVentasCore.DAL;
using FSVentasCore.Models.Dirreciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class MunicipiosBLL
    {

        public static List<Municipios> GetLista()
        {
            var lista = new List<Municipios>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Municipios.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Municipios> GetListaId(int Id)
        {
            List<Municipios> list = new List<Municipios>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Municipios.Where(p => p.MunicipioId == Id).ToList();
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

