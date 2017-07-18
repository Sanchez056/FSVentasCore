using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class CategoriasArticulosBLL
    {
        public static bool Insertar(CategoriasArticulos ca)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(ca.CategoriaId);
                    if (p == null)
                        db.CategoriasArticulos.Add(ca);
                    else
                        db.Entry(ca).State = EntityState.Modified;
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
        public static bool Eliminar(CategoriasArticulos ca)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    db.Entry(ca).State = EntityState.Deleted;
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
        public static CategoriasArticulos Buscar(int Id)
        {
            var ca = new CategoriasArticulos();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    ca = db.CategoriasArticulos.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return ca;
        }
        public static List<CategoriasArticulos> GetLista()
        {
            var lista = new List<CategoriasArticulos>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.CategoriasArticulos.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<CategoriasArticulos> GetListaId(int Id)
        {
            List<CategoriasArticulos> list = new List<CategoriasArticulos>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.CategoriasArticulos.Where(p => p.CategoriaId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<CategoriasArticulos> ListarArticulos()
        {
            List<CategoriasArticulos> lista = null;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.CategoriasArticulos.ToList();
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
