using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class CotizacionesDetalles
    {
     
        [Key]
        public int CotizacionDetalleId { get; set; }

        public int CotizacionId { get; set; }

        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecXund { get; set; }

        public decimal SubTotal { get; set; }

        //public Cotizaciones Cotizacion { get; set; }

        public CotizacionesDetalles()
        {
            //Cotizacion = new Cotizaciones();
        }


    }
}
