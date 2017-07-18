using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string ClienteId { get; set; }
        
                            
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        //public ICollection<CotizacionDetalles> Detalle { get; set; }

        public Cotizaciones()
        {
            //Detalle = new HashSet<CotizacionDetalles>();
        }
    }
}
