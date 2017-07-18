using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class UsuariosBLL
    {
        public static bool Insertar(Usuarios a)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(a.UsuarioId);
                    if (p == null)
                        db.Usuarios.Add(a);
                    else
                        db.Entry(a).State = EntityState.Modified;
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
        public static bool Eliminar(Usuarios t)
        {
            bool resultado = false;
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    db.Entry(t).State = EntityState.Deleted;
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
        public static Usuarios Buscar(int Id)
        {
            var c = new Usuarios();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    c = db.Usuarios.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return c;
        }
        public static List<Usuarios> GetLista()
        {
            var lista = new List<Usuarios>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    lista = db.Usuarios.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Usuarios> GetListaId(int Id)
        {
            List<Usuarios> list = new List<Usuarios>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Usuarios.Where(p => p.UsuarioId == Id).ToList();
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

