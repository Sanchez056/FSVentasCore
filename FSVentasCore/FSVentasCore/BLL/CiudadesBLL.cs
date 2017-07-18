using FSVentasCore.DAL;
using FSVentasCore.Models.Dirreciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class CiudadesBLL
    {
        public static bool Insertar(Ciudades cid)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(cid.CiudadId);
                    if (p == null)
                        db.Ciudades.Add(cid);
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
        public static bool Eliminar(Ciudades cid)
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
        public static Ciudades Buscar(int Id)
        {
            var cid = new Ciudades();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    cid = db.Ciudades.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return cid;
        }
        public static List<Ciudades> GetLista()
        {
            var lista = new List<Ciudades>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Ciudades.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Ciudades> GetListaId(int Id)
        {
            List<Ciudades> list = new List<Ciudades>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Ciudades.Where(p => p.CiudadId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<Ciudades> ListarArticulos()
        {
            List<Ciudades> lista = null;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Ciudades.ToList();
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
