﻿using System;
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


        public string Articulos { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal Total { get; set; }

        public Ventas()
        {

        }
    }
}
