using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
