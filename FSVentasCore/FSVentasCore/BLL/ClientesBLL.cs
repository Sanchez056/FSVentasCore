using FSVentasCore.DAL;
using FSVentasCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.BLL
{
    public class ClientesBLL
    {
        public static bool Insertar(Clientes nuevo)
        {
            bool resultado = false;
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    var p = Buscar(nuevo.ClienteId);
                    if (p == null)
                        Conn.Clientes.Add(nuevo);
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
        public static bool Eliminar(Clientes nuevo)
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
        public static Clientes Buscar(int Id)
        {
            var c = new Clientes();
            using (var Conn = new FSVentasCoreDb())
            {
                try
                {
                    c = Conn.Clientes.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return c;
        }
        public static List<Clientes> GetLista()
        {
            var lista = new List<Clientes>();
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    lista = conexion.Clientes.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Clientes> GetListaId(int Id)
        {
            List<Clientes> list = new List<Clientes>();
            using (var db = new FSVentasCoreDb())
            {
                try
                {
                    list = db.Clientes.Where(p => p.ClienteId == Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<Clientes> ListarClientes()
        {
            List<Clientes> listado = null;
            using (var conexion = new FSVentasCoreDb())
            {
                try
                {
                    listado = conexion.Clientes.ToList();
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

