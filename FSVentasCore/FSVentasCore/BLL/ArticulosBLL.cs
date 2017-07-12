using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class ArticulosBLL
    {
        public static bool Insertar(Articulos nuevo)
        {
            bool resultado = false;
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(nuevo.ArticuloId);
                    if (p == null)
                        Conn.Articulos.Add(nuevo);
                    else
                        Conn.Entry(nuevo).State = EntityState.Modified;
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
        public static bool Eliminar(Articulos nuevo)
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
        public static Articulos Buscar(int Id)
        {
            var c = new Articulos();
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    c = Conn.Articulos.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return c;
        }
        public static List<Articulos> GetLista()
        {
            var lista = new List<Articulos>();
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    lista = conexion.Articulos.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Articulos> GetListaId(int Id)
        {
            List<Articulos> list = new List<Articulos>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Articulos.Where(p => p.ArticuloId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<Articulos> ListarArticulos()
        {
            List<Articulos> listado = null;
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    listado = conexion.Articulos.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
    }
}

