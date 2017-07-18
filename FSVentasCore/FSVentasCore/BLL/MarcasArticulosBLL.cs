using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class MarcasArticulosBLL
    {
        public static bool Insertar(MarcasArticulos cid)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(cid.MarcaId);
                    if (p == null)
                        db.MarcasArticulos.Add(cid);
                    else
                        db.Entry(cid).State = EntityState.Modified;
                    db.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Eliminar(MarcasArticulos cid)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    db.Entry(cid).State = EntityState.Deleted;
                    db.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static MarcasArticulos Buscar(int Id)
        {
            var cid = new MarcasArticulos();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    cid = db.MarcasArticulos.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cid;
        }
        public static List<MarcasArticulos> GetLista()
        {
            var lista = new List<MarcasArticulos>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.MarcasArticulos.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<MarcasArticulos> GetListaId(int Id)
        {
            List<MarcasArticulos> list = new List<MarcasArticulos>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.MarcasArticulos.Where(p => p.MarcaId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<MarcasArticulos> ListarArticulos()
        {
            List<MarcasArticulos> lista = null;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.MarcasArticulos.ToList();
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
